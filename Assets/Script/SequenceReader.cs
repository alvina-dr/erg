using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using FMODUnity;

public class SequenceReader : MonoBehaviour
{
    public int sequenceIndex = 0;
    public List<SequenceData> sequenceList = new List<SequenceData>(); 
    private bool stopReading = false;
    [SerializeField] private TextMeshProUGUI textUI;
    [SerializeField] private FMOD.Studio.EventInstance audioEvent;

    private void Start()
    {
        ShowSequence(sequenceList[sequenceIndex]);
    }

    public void ShowSequence(SequenceData _sequence)
    {
        Debug.Log(_sequence.text);
        audioEvent = RuntimeManager.CreateInstance("event:/1n");
        textUI.text = _sequence.text;
        if (_sequence.sequenceType == SequenceData.SequenceType.Choice)
        {
            ShowChoice(_sequence);
        }
    }

    public void ShowChoice(SequenceData _sequence)
    {
        //get buttons, change value of button depending on which button is clicked, etc
    }

    public void NextSequence()
    {
        sequenceIndex++;
        if (sequenceIndex >= sequenceList.Count) //if last sequence
        {
            Debug.Log("ENDING");
        } else
        {
            ShowSequence(sequenceList[sequenceIndex]);
        }
    }
}
