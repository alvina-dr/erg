using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SequenceReader : MonoBehaviour
{
    public float chrono;
    public int sequenceIndex = 0;
    public List<SequenceData> sequenceList = new List<SequenceData>(); 
    public int lineIndex = 0;
    private bool stopReading = false;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private TextMeshProUGUI textUI;

    void Update()
    {
        if (stopReading) return;
        chrono += Time.deltaTime;
        if (sequenceList[sequenceIndex].textLineList[lineIndex].timer <= chrono)
        {
            ShowLine(sequenceList[sequenceIndex].textLineList[lineIndex]);
        }
    }

    private void Start()
    {
        audioSource.clip = sequenceList[sequenceIndex].audioClip;
        audioSource.Play();
    }

    public void ShowLine(SequenceData.TextLine _textLine)
    {
        Debug.Log(_textLine.text);
        textUI.text = _textLine.text;
        StartCoroutine(HideLine(_textLine));
        lineIndex++;
        if (lineIndex >= sequenceList[sequenceIndex].textLineList.Count)
        {
            NextSequence();
        }
    }

    public void NextSequence()
    {
        lineIndex = 0;
        sequenceIndex++;
        chrono = 0;
        if (sequenceIndex >= sequenceList.Count) //if last sequence
        {
            stopReading = true;
        } else
        {
            audioSource.clip = sequenceList[sequenceIndex].audioClip;
            audioSource.Play();
        }
    }

    IEnumerator HideLine(SequenceData.TextLine _textLine)
    {
        yield return new WaitForSeconds(_textLine.length);
        Debug.Log("HIDE LINE");
        if (textUI.text == _textLine.text) textUI.text = "";
    }
}
