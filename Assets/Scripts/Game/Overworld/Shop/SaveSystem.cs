using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Game.Overworld.Shop
{
    public static class SaveSystem
    {
        public static void SaveScore(PlayerData data)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/playerData.txt";
            FileStream stream = new FileStream(path, FileMode.Create);
            
            formatter.Serialize(stream, data);
            stream.Close();

        }

        public static PlayerData LoadScore()
        {
            string path = Application.persistentDataPath + "/playerData.txt";
            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);

                PlayerData data = formatter.Deserialize(stream) as PlayerData;

                stream.Close();

                return data;
            }
            return new PlayerData();
        }
    }
}
