using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveEx(Ex_Food_Value ex_Food_Value)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/ex_protoype_save.hazsha";
        FileStream stream = new FileStream(path, FileMode.Create);

        Ex_Data data = new Ex_Data(ex_Food_Value);

        formatter.Serialize(stream, data);
        stream.Close();
        
    }

    public static Ex_Data LoadEx()
    {
        string path = Application.persistentDataPath + "/ex_protoype_save.hazsha";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Ex_Data data = formatter.Deserialize(stream) as Ex_Data;
            stream.Close();

            return data;
        }
        else 
        { 
            Debug.LogError("save file not found" + path);
            return null;
        }
    }

    
}
