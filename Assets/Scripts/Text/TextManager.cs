using Event;
using ExtraTypes;
using Gameplay;
using SO;
using StaticObject;
using TMPro;
using UnityEngine;

namespace Text
{
    public class TextManager : MonoBehaviour
    {
        public static string s_CurrentString;
        public static VertexGradient s_Gradient;
        [SerializeField]
        private LevelManager levelManager;
        private DynamicLocalizedText mainText;
        [SerializeField]
        private StringRepresent[] stringRepresents;
        private LLong index = new LLong(0, 10);
        private void Awake()
        {
            EventManager.OnOverflowLimitEvent += ChangeCurrentString;
            EventManager.OnStageChangeEvent += LoadStrings;
            mainText = GameObject.FindGameObjectWithTag("MainText").
                GetComponent<DynamicLocalizedText>();
            LoadStrings();
        }
        private void Start()
        {
            ChangeCurrentString();
        }
        private void ChangeCurrentString()
        {
            s_CurrentString = stringRepresents[index.Current].MainString;
            s_Gradient = stringRepresents[index.Current].ColorOfString;
            index++;
            mainText.UpdateKey(s_CurrentString, s_Gradient);
        }
        private void LoadStrings()
        {
            // TODO: probably replacing to GO container of SO will be better
            switch (levelManager.CurrentStage.Current)
            {
                case 0: stringRepresents =
                        Resources.LoadAll<StringRepresent>("SOExamples/FirstLevel");
                    break;
                case 1: stringRepresents =
                        Resources.LoadAll<StringRepresent>("SOExamples/SecondLevel");
                    break;
            }
            index.Limit = stringRepresents.Length;
            StaticContainer.s_CurrentStageLimit = (int)index.Limit;
        }
    }
}