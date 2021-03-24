using UnityEngine;
using ExtraTypes;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static string CurrentString;
    public LLong AmountOfLeveling = new LLong(0, 10);
    public LLong CurrentLevel = new LLong(0, 1, false, 0, false);
    public ClickManager clickM;
    public static GameManager inst;
    private TextMeshProUGUI mainText;
    [SerializeField]
    private StringRepresent[] stringRepresents;
    private int currentIndex;
    private void Awake()
    {
        AmountOfLeveling = new LLong(0, 10);
        if (inst == null) inst = this;
        else if (inst != this) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        stringRepresents = LoadStrings();

        mainText = GameObject.FindGameObjectWithTag("MainText").GetComponent<TextMeshProUGUI>();
        EventManager.OnOverflowLimitEvent += ChangeCurrentString;
        EventManager.OnOverflowLimitEvent += IncreaseLeveling;
        ChangeCurrentString();
    }
    private void ChangeCurrentString()
    {
        CurrentString = stringRepresents[currentIndex].MainString;
        mainText.text = CurrentString;
        mainText.colorGradient = stringRepresents[currentIndex].ColorOfString;
        currentIndex = currentIndex > stringRepresents.Length - 2 ? 0 : ++currentIndex;
    }
    private void IncreaseLeveling()
    {
        if (AmountOfLeveling.AmountOfOverFlow(1) > 0)
        {
            CurrentLevel++;
            stringRepresents = LoadStrings();
        }
        AmountOfLeveling++;
    }
    private StringRepresent[] LoadStrings()
    {
        switch (CurrentLevel.Current)
        {
            case 0: return Resources.LoadAll<StringRepresent>("SOExamples/FirstLevel");
            case 1: return Resources.LoadAll<StringRepresent>("SOExamples/SecondLevel");
            default: return null;
        }
    }
}
