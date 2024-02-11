using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "Sequence", menuName = "ScriptableObjects/Sequence", order = 1)]
public class SequenceData : ScriptableObject
{
    public enum SequenceType
    {
        Narration = 0,
        Choice = 1
    }
    public SequenceType sequenceType;
    public FMODUnity.EventReference audioEvent;
    [TextArea(4, 10)]
    public string text;
    [ShowIf("sequenceType", SequenceType.Choice)]
    [HorizontalGroup]
    public List<SequenceData> leftChoice;
    [ShowIf("sequenceType", SequenceType.Choice)]
    [HorizontalGroup]
    public List<SequenceData> rightChoice;
}
