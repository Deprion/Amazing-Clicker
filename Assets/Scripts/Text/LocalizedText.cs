using Localization;
using TMPro;
using UnityEngine;

namespace Text
{
    public class LocalizedText : MonoBehaviour
    {
        [SerializeField]
        protected string key;
        protected TextMeshProUGUI txt;
        protected void Start()
        {
            txt = GetComponent<TextMeshProUGUI>();
            txt.text = LocalizationManager.inst.GetValue(key);
        }

    }
}
