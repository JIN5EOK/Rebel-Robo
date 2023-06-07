using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MapEditor))]
public class MapEditorInspector : Editor
{
    private Camera cam;
    private MapEditor editor;
    private Event curEvent;
    
    private enum SelectType
    {
        Tile,
        Entity
    }
    SelectType selectType;

    
    // 마우스 클릭 위치를 월드 포지션으로 변환
    private Vector3 GetMousePos()
    {
        Vector3 mousePos = curEvent.mousePosition *= EditorGUIUtility.pixelsPerPoint;
        mousePos.y = cam.pixelHeight - mousePos.y;
        mousePos = cam.ScreenToWorldPoint(mousePos);
        Vector3 createPos = new Vector3(Mathf.Floor(mousePos.x / editor.cellSize) * editor.cellSize + editor.cellSize / 2f,
            0f, Mathf.Floor(mousePos.z / editor.cellSize) * editor.cellSize + editor.cellSize / 2f);

        return createPos;
    }
    
    private void CreateObject()
    {
        
        Vector3 createPos = GetMousePos();

        GameObject obj;
        if (selectType == SelectType.Entity)
        {
            createPos.y = editor.entityY; // 오브젝트 종류에 따라 일정한 y좌표에 생성되도록 값 설정
            if (CheckOverlap(createPos) == true) // 해당 좌표에 겹치는 오브젝트가 있으면 생성 안함
                return;
            // if (editor.selectEntity == MapEditor.Entitys.PlayerHQ && selectType == SelectType.Entity) // 플레이어 HQ, 플레이어는 여러개 생성 불가하도록
            // {
            //     foreach(PlayerHQ hq in FindObjectsOfType<PlayerHQ>())
            //         Undo.DestroyObjectImmediate(hq.gameObject);
            // }
            if (editor.selectEntity == MapEditor.Entitys.Player && selectType == SelectType.Entity)
            {
                foreach(Player p in FindObjectsOfType<Player>())
                    Undo.DestroyObjectImmediate(p.gameObject);
            }
            obj = (GameObject)PrefabUtility.InstantiatePrefab(editor.entityPrefabs[(int)editor.selectEntity]);
        }
        else if (selectType == SelectType.Tile)
        {
            createPos.y = editor.tileY;
            if (CheckOverlap(createPos) == true)
                return;
            obj = (GameObject)PrefabUtility.InstantiatePrefab(editor.tilePrefabs[(int)editor.selectTile]);
        }
            
        else
            return;
        
        obj.transform.parent = editor.transform.GetChild((int)selectType); // Tiles, Entitys 오브젝트 하위에 들어가도록 정리
        obj.transform.position = createPos; 
        Undo.RegisterCreatedObjectUndo(obj, "Create Object"); // Undo(Ctrl+Z)로 오브젝트 생성을 되돌릴 수 있게 등록함.
    }
    
    private GameObject CheckOverlap(Vector3 _pos) // 동일한 좌표에 오브젝트가 존재하면 반환
    {
        Transform[] transforms = editor.transform.GetChild((int)selectType).GetComponentsInChildren<Transform>();
        
        foreach (Transform t in transforms)
        {
            Debug.Log(t.transform.position);
            if (t.transform.position.x == _pos.x && t.transform.position.z == _pos.z)
            {
                return t.gameObject;
                break;
            }
        }
        
        return null;
    }
    private void DeleteObject() // 클릭좌표 오브젝트 삭제
    {
        Vector3 mousePos = GetMousePos();
        if(selectType == SelectType.Entity)
            mousePos.y = editor.entityY;
        else if(selectType == SelectType.Tile)
            mousePos.y = editor.tileY;
        
        GameObject delObj = CheckOverlap(mousePos);
        if(delObj != null)
        {
            Undo.DestroyObjectImmediate(delObj);
        }
    }


    public override void OnInspectorGUI()
    {
        string[] t = new[] { "Tile", "Entity" };
        GUILayout.Label("Create Type");
        selectType = (SelectType)GUILayout.Toolbar((int)selectType, t); // selectType에 값을 반환하는 툴바 생성
        base.OnInspectorGUI();
    }
    
    public void OnSceneGUI()
    {
        editor = (MapEditor)target;
        curEvent = Event.current;
        cam = SceneView.lastActiveSceneView.camera; // 활성화된 씬뷰
        SceneView.lastActiveSceneView.rotation = Quaternion.Euler(90, 0, 0); // 에디터 선택시 항상 하늘 위 수직에서 바라보도록 함.
        SceneView.lastActiveSceneView.orthographic = true; // 에디터 선택시 원근감 제거

        //mousePos.z *= -1;
        if (curEvent.type == EventType.MouseDown && curEvent.button == 0)
        {
            int curGuiID = GUIUtility.GetControlID(FocusType.Passive); 
            curEvent.Use();
            GUIUtility.hotControl = curGuiID; // 다른 컨트롤이 클릭 이벤트에 접근할 수 없도록 함.
            CreateObject();
        }
        else if (curEvent.type == EventType.MouseDrag && curEvent.button == 0)
        {
            CreateObject();
        }
        if (curEvent.type == EventType.MouseDown && curEvent.button == 1)
        {
            int curGuiID = GUIUtility.GetControlID(FocusType.Passive);
            curEvent.Use();
            GUIUtility.hotControl = curGuiID;
            
            DeleteObject();
        }
        else if (curEvent.type == EventType.MouseDrag && curEvent.button == 1)
        {
            DeleteObject();
        }
    }
}
