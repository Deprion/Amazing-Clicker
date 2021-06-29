using ExtraTypes;
using Gameplay;
using System.IO;
using UnityEngine;

namespace Data
{
    public class DataManager : MonoBehaviour
    {
        [SerializeField]
        private ClickManager clickM;
        [SerializeField]
        private LevelManager levelM;
        private bool IsLoaded;
        private string dataPath;
        [SerializeField]
        public class Data
        {
            public LLong ClickAmount;
            public long PowerOfClick;
            public LLong AmountOfLeveling;
            public LLong CurrentStage;
            public Data(LLong _clickAmount, long _powerOfClick, LLong _amountOfLeveling, LLong _currentStage)
            {
                ClickAmount = _clickAmount;
                PowerOfClick = _powerOfClick;
                AmountOfLeveling = _amountOfLeveling;
                CurrentStage = _currentStage;
            }
        }
        private void Awake()
        {
            dataPath = Application.persistentDataPath + "/Data.json";
            LoadData();
        }
        public void LoadData()
        {
            if (File.Exists(dataPath))
            {
                Data data = JsonUtility.FromJson<Data>(File.ReadAllText(dataPath));
                clickM.ClickAmount = data.ClickAmount;
                clickM.ClickToAdd = data.PowerOfClick;
                levelM.AmountToLeveling = data.AmountOfLeveling;
                levelM.CurrentStage = data.CurrentStage;
            }
            IsLoaded = true;
        }
        private void SaveData()
        {
            Data data = new Data(clickM.ClickAmount, clickM.ClickToAdd,
                levelM.AmountToLeveling, levelM.CurrentStage);
            File.WriteAllText(dataPath, JsonUtility.ToJson(data));
        }
        private void OnApplicationFocus(bool focus)
        {
            if (IsLoaded) SaveData();
        }
        private void OnApplicationQuit()
        {
            if (IsLoaded) SaveData();
        }
    }
}