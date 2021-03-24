using UnityEngine;
using ExtraTypes;
using System.IO;

public class DataManager : MonoBehaviour
{
    public ClickManager clickM;
    private GameManager gameM;
    private bool IsLoaded;
    private string dataPath;
    [SerializeField]
    public class Data
    {
        public LLong ClickAmount;
        public long PowerOfClick;
        public LLong AmountOfLeveling;
        public LLong CurrentLevel;
        public Data(LLong _clickAmount, long _powerOfClick, LLong _amountOfLeveling, LLong _currentLevel)
        {
            ClickAmount = _clickAmount;
            PowerOfClick = _powerOfClick;
            AmountOfLeveling = _amountOfLeveling;
            CurrentLevel = _currentLevel;
        }
    }
    private void Awake()
    {
        dataPath = Application.persistentDataPath + "/Data.json";
        gameM = GetComponent<GameManager>();
        LoadData();
    }
    public void LoadData()
    {
        if (File.Exists(dataPath))
        {
            Data data = JsonUtility.FromJson<Data>(File.ReadAllText(dataPath));
            clickM.ClickAmount = data.ClickAmount;
            clickM.ClickToAdd = data.PowerOfClick;
            gameM.AmountOfLeveling = data.AmountOfLeveling;
            gameM.CurrentLevel = data.CurrentLevel;
        }
        IsLoaded = true;
    }
    private void SaveData()
    {
        Data data = new Data(clickM.ClickAmount, clickM.ClickToAdd,
            gameM.AmountOfLeveling, gameM.CurrentLevel);
        File.WriteAllText(dataPath, JsonUtility.ToJson(data));
    }
    private void OnApplicationFocus(bool focus)
    {
        if (IsLoaded) SaveData();
    }
    private void OnApplicationQuit()
    {
        if(IsLoaded) SaveData();
    }
}
