using UnityEngine;
using TMPro;
using ExtraTypes;

public class ClickManager : MonoBehaviour
{
    public LLong ClickAmount = new LLong(0, 10);
    public long ClickToAdd = 1;
    public TextMeshProUGUI mainText;
    private void Start()
    {
        mainText.text = ClickAmount.ToString();
    }
    private void OnMouseDown()
    {
        if (!ClickAmount.IncreaseCurrent(ClickToAdd))
        {
            mainText.text = ClickAmount.ToString();
        }
        else 
        {
            EventManager.InvokeOverflowLimit();
            mainText.text = ClickAmount.ToString();
        }
    }
}
