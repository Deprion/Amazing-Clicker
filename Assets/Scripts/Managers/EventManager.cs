using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void OnOverflowLimitDelegate();
    public static event OnOverflowLimitDelegate OnOverflowLimitEvent;
    public delegate void ChangeMainTextKeyDelegate(string key);
    public static event ChangeMainTextKeyDelegate ChangeMainTextKeyEvent;
    public static void InvokeOverflowLimit()
    {
        OnOverflowLimitEvent?.Invoke();
        ChangeMainTextKeyEvent?.Invoke(GameManager.CurrentString);
    }
}
