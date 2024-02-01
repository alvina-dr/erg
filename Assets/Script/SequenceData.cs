using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Sequence", menuName = "ScriptableObjects/Sequence", order = 1)]
public class SequenceData : ScriptableObject
{
    public AudioClip audioClip;
    public List<TextLine> textLineList = new List<TextLine>(); 

    [System.Serializable]
    public class TextLine
    {
        public string text;
        public float timer;
        public float length;
    }
}
