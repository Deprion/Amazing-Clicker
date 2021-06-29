using Event;
using ExtraTypes;
using StaticObject;
using UnityEngine;

namespace Gameplay
{
    public class LevelManager : MonoBehaviour
    {
        public LLong AmountToLeveling = new LLong(0, 10);
        public LLong CurrentStage = new LLong(0, 1, false, 0, false);
        private void Awake()
        {
            EventManager.OnOverflowLimitEvent += IncreaseLeveling;
            AmountToLeveling.Limit = StaticContainer.s_CurrentStageLimit;
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
            EventManager.InvokeOnStageChange();
            AmountToLeveling.Limit = StaticContainer.s_CurrentStageLimit;
        }
    }
}
