using UnityEngine;
using ExtraTypes;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static string CurrentString;
    public LLong AmountToLeveling = new LLong(0, 10);
    public LLong CurrentStage = new LLong(0, 1, false, 0, false);
    public ClickManager clickM;
    public static GameManager inst;
    private TextMeshProUGUI mainText;
    [SerializeField]
    private StringRepresent[] stringRepresents;
    private int currentIndex;
    private void Awake()
    {
        AmountToLeveling = new LLong(0, 10);
        if (inst == null) inst = this;
        else if (inst != this) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        stringRepresents = LoadStrings();
        AmountToLeveling.Limit = stringRepresents.Length;

        mainText = GameObject.FindGameObjectWithTag("MainText").GetComponent<TextMeshProUGUI>();
        EventManager.OnOverflowLimitEvent += ChangeCurrentString;
        EventManager.OnOverflowLimitEvent += IncreaseLeveling;
        ChangeCurrentString();
    }
    private void ChangeCurrentString()
    {
        // TODO: gradient must be changed not here
        CurrentString = stringRepresents[currentIndex].MainString;
        mainText.colorGradient = stringRepresents[currentIndex].ColorOfString;
        currentIndex = currentIndex > stringRepresents.Length - 2 ? 0 : ++currentIndex;
    }
    // TODO: transform to another class
    private void IncreaseLeveling()
    {
        // check for overflow not needed, cuz only invoke when overflow
        if (AmountToLeveling.AddValue(1))
        {
            IncreaseStage();
        }
    }
    private void IncreaseStage()
    {
        CurrentStage++;
        stringRepresents = LoadStrings();
        AmountToLeveling.Limit = stringRepresents.Length;
    }
    private StringRepresent[] LoadStrings()
    {
        // TODO: probably replacing to GO container of SO will be better
        switch (CurrentStage.Current)
        {
            case 0: return Resources.LoadAll<StringRepresent>("SOExamples/FirstLevel");
            case 1: return Resources.LoadAll<StringRepresent>("SOExamples/SecondLevel");
            default: return null;
        }
    }
}
