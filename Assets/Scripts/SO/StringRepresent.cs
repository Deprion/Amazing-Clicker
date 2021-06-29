using UnityEngine;
using TMPro;

namespace SO
{
    [CreateAssetMenu(fileName = "StringExample")]
    public class StringRepresent : ScriptableObject
    {
        public string MainString;
        public VertexGradient ColorOfString = new VertexGradient(Color.black);
    }
}