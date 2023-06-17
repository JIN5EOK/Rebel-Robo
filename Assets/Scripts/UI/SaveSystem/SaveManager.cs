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
        //������� �÷��̾� ������ �κ��丮 ��� �ܾ��ƾ� �� ������.
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
        //������ �����ϴ������� üũ.
        if (!File.Exists(GetPath()))
        {
            Debug.Log("���̺� ������ �������� ����.");
            return null;  
        }

        string encryptData = LoadFile(GetPath());
        string decryptData = Decrypt(encryptData);

        Debug.Log(decryptData);

        SaveData sd = JsonToData(decryptData);
        return sd;
    }

    ////////////////////////////////////////////////////////////////////////////////////////

    //���̺� �����͸� json string���� ��ȯ
    static string DataToJson(SaveData sd)
    {
        string jsonData = JsonUtility.ToJson(sd);
        return jsonData;
    }

    //json string�� SaveData�� ��ȯ
    static SaveData JsonToData(string jsonData)
    {
        SaveData sd = JsonUtility.FromJson<SaveData>(jsonData);
        return sd;
    }

    ////////////////////////////////////////////////////////////////////////////////////////

    //json string�� ���Ϸ� ����
    static void SaveFile(string jsonData)
    {
        using (FileStream fs = new FileStream(GetPath(), FileMode.Create, FileAccess.Write))
        {
            //���Ϸ� ������ �� �ְ� ����Ʈȭ
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(jsonData);

            //bytes�� ���빰�� 0 ~ max ���̱��� fs�� ����
            fs.Write(bytes, 0, bytes.Length);
        }
    }

    //���� �ҷ�����
    static string LoadFile(string path)
    {
        using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            //������ ����Ʈȭ ���� �� ���� ������ ����
            byte[] bytes = new byte[(int)fs.Length];

            //���Ͻ�Ʈ������ ���� ����Ʈ ����
            fs.Read(bytes, 0, (int)fs.Length);

            //������ ����Ʈ�� json string���� ���ڵ�
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

    //������ �ּҸ� ��ȯ
    static string GetPath()
    {
        return Path.Combine(Application.persistentDataPath, "save.abcd");
    }
}
