using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace Game
{

    public class DataController : MonoBehaviour
    {
        public GameData m_gameData;
        private string m_path = "";

        public void InitData()
        {
            m_path = Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
            try
            {
                LoadGameData();
            }
            catch
            {
                m_gameData = new GameData(0, 0, 0);
                SaveGameData();
            }
        }

        public void SaveGameData()
        {
            string json = JsonUtility.ToJson(m_gameData);
            using StreamWriter writer = new StreamWriter(m_path);
            writer.Write(json);
        }

        public void LoadGameData()
        {
            using StreamReader reader = new StreamReader(m_path);
            string json = reader.ReadToEnd();
            m_gameData = JsonUtility.FromJson<GameData>(json);

        }
    }

}