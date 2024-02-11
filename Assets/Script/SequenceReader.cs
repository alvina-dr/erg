using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using FMODUnity;
using DG.Tweening;

public class SequenceReader : MonoBehaviour
{
    public int sequenceIndex = 0;
    public List<SequenceData> sequenceList = new List<SequenceData>(); 
    [SerializeField] private TextMeshProUGUI textPrefab;
    [SerializeField] private Transform textContainer;
    [SerializeField] private Scrollbar scrollBar;
    [SerializeField] private FMOD.Studio.EventInstance audioEvent;

    private void Start()
    {
        ShowSequence(sequenceList[sequenceIndex]);
    }

    public void ShowSequence(SequenceData _sequence)
    {
        Debug.Log(_sequence.text);
        audioEvent.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        audioEvent = RuntimeManager.CreateInstance(_sequence.audioEvent);
        audioEvent.start();
        TextMeshProUGUI _text = Instantiate(textPrefab, textContainer);
        _text.text = _sequence.text;
        if (_sequence.sequenceType == SequenceData.SequenceType.Choice)
        {
            ShowChoice(_sequence);
        }
        StartCoroutine(ScrollDown());
    }

    public IEnumerator ScrollDown()
    {
        yield return new WaitForSeconds(.3f);
        float _value = scrollBar.value;
        Debug.Log(_value);
        DOTween.To(x => scrollBar.value = x, _value, 0, 0.5f);
        //scrollBar.value = 0;
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
