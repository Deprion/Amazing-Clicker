using System.Collections;

[System.Serializable]
public class LocalizationData : IEnumerable
{
    public LocalizationItem[] translations;

    public IEnumerator GetEnumerator()
    {
        return translations.GetEnumerator();
    }
}
[System.Serializable]
public class LocalizationItem
{
    public string key;
    public string value;
}
