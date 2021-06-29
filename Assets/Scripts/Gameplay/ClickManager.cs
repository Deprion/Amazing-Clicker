using ExtraTypes;
using TMPro;
using UnityEngine;
using Event;

namespace Gameplay
{
    public class ClickManager : MonoBehaviour
    {
        public LLong ClickAmount = new LLong(0, 10, true, 2, true);
        public long ClickToAdd = 1;
        [SerializeField]
        private TextMeshProUGUI valueText;
        private void Start()
        {
            valueText.text = ClickAmount.ToString();
        }
        private void OnMouseDown()
        {
            if (ClickAmount.AddValue(ClickToAdd))
            {
                EventManager.InvokeOverflowLimit();
            }
            valueText.text = ClickAmount.ToString();
        }
    }
}
