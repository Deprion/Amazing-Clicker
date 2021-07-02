using Event;
using ExtraTypes;
using StaticObject;
using UnityEngine;
using Other;

namespace Gameplay
{
    public class LevelManager : MonoBehaviour
    {
        public LLong AmountToLeveling = new LLong(0, 10);
        public LLong CurrentStage = new LLong(0, 1, false, 0, false);
        public LevelContainer[] levelContainer;
        private void Awake()
        {
            EventManager.OnOverflowLimitEvent += IncreaseLeveling;
            AmountToLeveling.Limit = levelContainer[CurrentStage.Current]
                .StringRepresentArray.Length;
        }
        private void IncreaseLeveling()
        {
            if (AmountToLeveling.AddValue(1))
            {
                IncreaseStage();
            }
        }
        private void IncreaseStage()
        {
            CurrentStage++;
            StaticContainer.s_CurrentStageLimit = levelContainer[CurrentStage.Current]
                .StringRepresentArray.Length;
            AmountToLeveling.Limit = levelContainer[CurrentStage.Current]
                .StringRepresentArray.Length;
            AmountToLeveling.Current = 0;
            EventManager.InvokeOnStageChange();
        }
    }
}
