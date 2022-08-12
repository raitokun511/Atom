using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.Networking;
using System.Security.Cryptography;
using System.Linq;
using System;
using UnityEngine.SceneManagement;

[Serializable]
public class UserData
{
    public List<int> bagItem;


    public static void Save(Ball[,] board = null, bool isPlaying = false)
    {
        UserData data = new UserData();

        data.bagItem = GM.bagItem;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file;
        if (File.Exists(Application.persistentDataPath + "/userdata.dat"))
        {

            file = File.Open(Application.persistentDataPath + "/userdata.dat", FileMode.Open);
        }
        else
        {
            file = File.Create(Application.persistentDataPath + "/userdata.dat");
        }

        bf.Serialize(file, data);
        file.Close();

    }
    public static int[] Load()
    {
        bool dataChange = false;

        if (File.Exists(Application.persistentDataPath + "/userdata.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/userdata.dat", FileMode.Open);
            UserData data = (UserData)bf.Deserialize(file);
            file.Close();
            GM.bagItem = data.bagItem;
            
        }
        else
        {
            GM.bagItem = new List<int>();
        }
        return null;
    }

    public static void Delete()
    {
        File.Delete(Application.persistentDataPath + "/userdata.dat");

    }

    public static bool CheckSaved()
    {
        if (File.Exists(Application.persistentDataPath + "/userdata.dat"))
            return true;
        return false;
    }

}
