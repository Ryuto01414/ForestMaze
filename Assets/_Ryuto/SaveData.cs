using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Reflection;
using System.Reflection.Emit;

public class TestData:ISaveable
{
    public int a { get; set; } = 5;
    public string b { get; set; } = "test";
}

public interface ISaveable
{

}

public class SaveManager<Data> where Data : ISaveable, new()
{
    //�V���O���g��
    private static SaveManager<Data> instance;
    public static SaveManager<Data> Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new SaveManager<Data>();
            }
            return instance;
        }
    }
    



    //�f�[�^�̎Q��
    //Data data;
    Type dataType = typeof(Data);
    private const string SAVE_FILE_PATH = "save.json";
    public PropertyInfo[] propsInfo;

    //�R���X�g���N�^
    private SaveManager()
    {
        //Data����������public�v���p�e�B�̏����擾
        propsInfo = dataType.GetProperties(
            BindingFlags.Public |
            BindingFlags.DeclaredOnly |
            BindingFlags.Instance);
        foreach(PropertyInfo p in propsInfo)
        {
            Debug.Log("�v���p�e�B:"+p.Name);
        }
        Debug.Log("�v���p�e�B��" + propsInfo.Length);

        
        Debug.Log("�R���X�g���N�^");
    }
   

    public void SaveData(Data d)
    {
        Debug.Log("SavedData");

        string json = JsonUtility.ToJson(d);
        Debug.Log("" + json);
#if UNITY_EDITOR
        string path = Directory.GetCurrentDirectory();
#else 
        string path = AppDomain..CurrentDomain.BaseDirectory.TrimEnd('\\');
#endif
        path += ("/" + SAVE_FILE_PATH);
        StreamWriter writer = new StreamWriter(path, false);
        writer.WriteLine(json);
        writer.Flush();
        writer.Close();
    }

    

    /// <summary>
    /// �Z�[�u�������v���p�e�B�̃C���f�b�N�X���擾����
    /// </summary>
    /// <param name="propertyName"></param>
    /// <returns></returns>
    public int GetPropertyIndex(string propertyName)
    {
        for(int i = 0; i < propsInfo.Length; i++)
        {
            if (propsInfo[i].Name == propertyName)
            {
                return i;
            }
        }
        Debug.Log("�v���p�e�B�̃C���f�b�N�X��������܂���ł����B");
        return -1;
    }


    private void CheckSavedData()
    {

    }

    //�Z�[�u���Ă���f�[�^�����[�h����
    public Data LoadData()
    {
        Data data;
        try
        {
#if UNITY_EDITOR
            string path = Directory.GetCurrentDirectory();
#else
        string path = AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\');
#endif
            FileInfo info = new FileInfo(path + "/" + SAVE_FILE_PATH);
            StreamReader reader = new StreamReader(info.OpenRead());
            string json = reader.ReadToEnd();
            data = JsonUtility.FromJson<Data>(json);
        }
        catch (Exception e)
        {
            data = new Data();
        }
        return data;
    }

}

