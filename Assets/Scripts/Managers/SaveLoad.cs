using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public class SaveLoad {


    public static void Save(PlayerBase player) {

        BinaryFormatter bf = new BinaryFormatter();
        string path = Application.persistentDataPath + "/savedGames.gd";
        FileStream file = new FileStream(path, FileMode.Create);
        Game data = new Game(player);
        bf.Serialize(file, data);
        file.Close();

    }
    public static bool DoesFileExist() {
        string path = Application.persistentDataPath + "/savedGames.gd";
        return File.Exists(path);
    }
    public static void DeleteFile() {
        string path = Application.persistentDataPath + "/savedGames.gd";

    }
    public static Game Load() {
        string path = Application.persistentDataPath + "/savedGames.gd";
        if (File.Exists(path)) {

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(path, FileMode.Open);
            Game data = bf.Deserialize(file) as Game;
            file.Close();

            return data;
        }
        else {

            return null;
        }
    }

}
