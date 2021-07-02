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
        private LevelManager lvlM;
        private DynamicLocalizedText mainText;
        private LLong index = new LLong(0, 10);
        private void Awake()
        {
            EventManager.OnOverflowLimitEvent += ChangeCurrentString;
            EventManager.OnStageChangeEvent += StageChanged;
            mainText = GameObject.FindGameObjectWithTag("MainText").
                GetComponent<DynamicLocalizedText>();
        }
        private void Start()
        {
            ChangeCurrentString();
        }
        private void ChangeCurrentString()
        {
            s_CurrentString = lvlM.levelContainer[lvlM.CurrentStage.Current]
                .StringRepresentArray[index.Current].NameString;
            s_Gradient = lvlM.levelContainer[lvlM.CurrentStage.Current]
                .StringRepresentArray[index.Current].ColorOfString;
            index++;
            mainText.UpdateKey(s_CurrentString, s_Gradient);
        }
        private void StageChanged()
        {
            index.Limit = StaticContainer.s_CurrentStageLimit;
            index.Current = 0;
        }
    }
}