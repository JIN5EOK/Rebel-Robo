using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private static readonly string privateKey = "Xe9LPoYi4y9zudX3VqmWtxJQ1fl1RvKD";

    GameManager gameManager;
    ProductData productData;
    MissionData missionData;

    public static SaveManager Instance;

    public int coinA;

    
    public void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        productData = GameObject.Find("ProductData").GetComponent<ProductData>();
        missionData = GameObject.Find("MissionData").GetComponent<MissionData>();
        if(File.Exists(GetPath()))
        {
            SaveData loadedData = Load();
            gameManager.coin = loadedData.savedCoin;
            productData.buyedHero = loadedData.saveHero;
            productData.buyedTower = loadedData.saveTower;
            productData.buyedSkill = loadedData.saveSkill;
            productData.buyedEquip = loadedData.saveEquip;
            gameManager.clearedStage = loadedData.LastClear;
        }
        
        

    }
    public void Save()
    {
        GameManager gameManager = GameManager.Instance;
        ProductData productData = ProductData.Instance;
        MissionData missionData = MissionData.Instance;
        //(int t_savedCoin, bool[] t_saveHero, bool[] t_saveTower, bool[] t_saveSkill, bool[] t_saveEquip, int t_LastClear, bool[,] t_saveMission)
        //원래라면 플레이어 정보나 인벤토리 등에서 긁어모아야 할 정보들.
        SaveData sd = new SaveData(
            GameManager.Instance.coin,
            ProductData.Instance.buyedHero,
            ProductData.Instance.buyedTower,
            ProductData.Instance.buyedSkill,
            ProductData.Instance.buyedEquip,
            GameManager.Instance.clearedStage,
            MissionData.Instance.clearedMission);

        string jsonString = DataToJson(sd);
        string encryptString = Encrypt(jsonString);
        SaveFile(encryptString);

        //coinA = sd.savedCoin;
    }

    public static SaveData Load()
    {
        //파일이 존재하는지부터 체크.
        if (!File.Exists(GetPath()))
        {
            Debug.Log("세이브 파일이 존재하지 않음.");
            return null;  
        }

        string encryptData = LoadFile(GetPath());
        string decryptData = Decrypt(encryptData);

        Debug.Log(decryptData);

        SaveData sd = JsonToData(decryptData);
        return sd;
    }

    ////////////////////////////////////////////////////////////////////////////////////////

    //세이브 데이터를 json string으로 변환
    static string DataToJson(SaveData sd)
    {
        string jsonData = JsonUtility.ToJson(sd);
        return jsonData;
    }

    //json string을 SaveData로 변환
    static SaveData JsonToData(string jsonData)
    {
        SaveData sd = JsonUtility.FromJson<SaveData>(jsonData);
        return sd;
    }

    ////////////////////////////////////////////////////////////////////////////////////////

    //json string을 파일로 저장
    static void SaveFile(string jsonData)
    {
        using (FileStream fs = new FileStream(GetPath(), FileMode.Create, FileAccess.Write))
        {
            //파일로 저장할 수 있게 바이트화
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(jsonData);

            //bytes의 내용물을 0 ~ max 길이까지 fs에 복사
            fs.Write(bytes, 0, bytes.Length);
        }
    }

    //파일 불러오기
    static string LoadFile(string path)
    {
        using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            //파일을 바이트화 했을 때 담을 변수를 제작
            byte[] bytes = new byte[(int)fs.Length];

            //파일스트림으로 부터 바이트 추출
            fs.Read(bytes, 0, (int)fs.Length);

            //추출한 바이트를 json string으로 인코딩
            string jsonString = System.Text.Encoding.UTF8.GetString(bytes);
            return jsonString;
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////

    private static string Encrypt(string data)
    {

        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(data);
        RijndaelManaged rm = CreateRijndaelManaged();
        ICryptoTransform ct = rm.CreateEncryptor();
        byte[] results = ct.TransformFinalBlock(bytes, 0, bytes.Length);
        return System.Convert.ToBase64String(results, 0, results.Length);

    }

    private static string Decrypt(string data)
    {

        byte[] bytes = System.Convert.FromBase64String(data);
        RijndaelManaged rm = CreateRijndaelManaged();
        ICryptoTransform ct = rm.CreateDecryptor();
        byte[] resultArray = ct.TransformFinalBlock(bytes, 0, bytes.Length);
        return System.Text.Encoding.UTF8.GetString(resultArray);
    }


    private static RijndaelManaged CreateRijndaelManaged()
    {
        byte[] keyArray = System.Text.Encoding.UTF8.GetBytes(privateKey);
        RijndaelManaged result = new RijndaelManaged();

        byte[] newKeysArray = new byte[16];
        System.Array.Copy(keyArray, 0, newKeysArray, 0, 16);

        result.Key = newKeysArray;
        result.Mode = CipherMode.ECB;
        result.Padding = PaddingMode.PKCS7;
        return result;
    }

    ////////////////////////////////////////////////////////////////////////////////////////

    //저장할 주소를 반환
    static string GetPath()
    {
        return Path.Combine(Application.persistentDataPath, "save.abcd");
    }
}
