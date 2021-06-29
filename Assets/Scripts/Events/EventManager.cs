using UnityEngine;

namespace Event
{
    public class EventManager : MonoBehaviour
    {
        public delegate void OnOverflowLimitDelegate();
        public static event OnOverflowLimitDelegate OnOverflowLimitEvent;
        public delegate void OnStageChangeDelegate();
        public static event OnStageChangeDelegate OnStageChangeEvent;
        public static void InvokeOverflowLimit()
        {
            OnOverflowLimitEvent?.Invoke();
        }
        public static void InvokeOnStageChange()
        {
            OnStageChangeEvent?.Invoke();
        }
    }
}