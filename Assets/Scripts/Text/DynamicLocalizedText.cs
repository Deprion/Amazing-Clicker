using Localization;
using TMPro;

namespace Text
{
    public class DynamicLocalizedText : LocalizedText
    {
        protected new void Start()
        {
            base.Start();
        }
        public void UpdateKey(string newKey, VertexGradient gradient)
        {
            key = newKey;
            txt.text = LocalizationManager.inst.GetValue(key);
            txt.colorGradient = gradient;
        }
    }
}
