
public class DynamicLocalizedText : LocalizedText
{
    protected new void Start()
    {
        base.Start();
        EventManager.ChangeMainTextKeyEvent += UpdateKey;
    }
    public void UpdateKey(string newKey)
    {
        key = newKey;
        txt.text = LocalizationManager.inst.GetValue(key);
    }
}
