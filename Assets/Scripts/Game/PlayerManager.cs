using Game.UI;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using Utility;

namespace Game.Overworld.Shop
{
    public class PlayerManager : GiveText
    
    {
        [SerializeField] private PlayerData data;
        public PlayerData Data => data;

        public PlayerData workingData;
        public static PlayerManager instance;


        [HideInInspector] public UnityEvent resetLevel;

        void Awake()
        {
            // data = SaveSystem.LoadScore();
            LoadData();
            workingData = (PlayerData)data.Clone();
            
            if (instance != null)
            {
                Destroy(gameObject);
            }

            instance = this;
            DontDestroyOnLoad(gameObject);
            
        }
        

        public void LoadWorkingData()
        {
            workingData = (PlayerData)data.Clone();
        }

        public void PushWorkingData()
        {
            data = (PlayerData)workingData.Clone();
        }

        public void ResetLevel()
        {
            resetLevel.Invoke();
            LoadWorkingData();
        }

        public void LevelComplete()
        {
            PushWorkingData();
            SaveData();
        }
        

        //This Saves all data
        public void SaveData()
        {
            // SaveSystem.SaveScore(data);
            SaveUtility.Save(data, Application.persistentDataPath, "data11");
        }

        //This Loads all data
        public void LoadData()
        {
            // data = SaveSystem.LoadScore();
            data = SaveUtility.Load<PlayerData>(Application.persistentDataPath, "data11");
        }
        

        private void OnApplicationQuit()
        {
            SaveData();
        }

        public override string GetText()
        {
            return "Coins: " + workingData.coins.ToString("N0");
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(PlayerManager))]
    public class PlayerManagerE : Editor
    {
        public override void OnInspectorGUI()
        {
            PlayerManager t = (PlayerManager)target;

            GUILayout.BeginHorizontal();
            if (GUILayout.Button("SaveData"))
            {
                t.SaveData();
            }

            if (GUILayout.Button("LoadData"))
            {
                t.LoadData();
            }

            EditorGUILayout.EndHorizontal();

            EditorGUILayout.PropertyField(serializedObject.FindProperty("data"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("workingData"));

            serializedObject.ApplyModifiedProperties();
        }
    }
#endif
}