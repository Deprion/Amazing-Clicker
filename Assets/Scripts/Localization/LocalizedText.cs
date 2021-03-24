using UnityEngine;
using TMPro;

public class LocalizedText : MonoBehaviour
{
    [SerializeField]
    private string key;
    private TextMeshProUGUI txt;
    void Start()
    {
        EventManager.ChangeMainTextKeyEvent += UpdateKey;
        txt = GetComponent<TextMeshProUGUI>();
        txt.text = LocalizationManager.inst.GetValue(key);
    }
    public void UpdateKey(string newKey)
    {
        key = newKey;
        txt.text = LocalizationManager.inst.GetValue(key);
    }
}
