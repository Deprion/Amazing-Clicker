using UnityEngine;
using TMPro;
using ExtraTypes;

public class ClickManager : MonoBehaviour
{
    public LLong ClickAmount = new LLong(0, 10, true, 2, true);
    public long ClickToAdd = 1;
    public TextMeshProUGUI mainText;
    private void Start()
    {
        mainText.text = ClickAmount.ToString();
    }
    private void OnMouseDown()
    {
        if (ClickAmount.AddValue(ClickToAdd))
        {
            EventManager.InvokeOverflowLimit();
        }
        mainText.text = ClickAmount.ToString();
    }
}
