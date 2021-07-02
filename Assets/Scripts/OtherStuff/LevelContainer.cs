using UnityEngine;

namespace Other
{
    [CreateAssetMenu(fileName = "StringExampleArray")]
    public class LevelContainer : ScriptableObject
    {
        public int Level;
        public StringRepresent[] StringRepresentArray;
    }
}