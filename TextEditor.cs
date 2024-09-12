using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextEditor : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _sizeCounter;
    [SerializeField] private TextMeshProUGUI _bestScore;

    public void UpdateTextScore(int score)
    {
        _sizeCounter.text = Convert.ToString(score);
    }
    public void UpdateTextBestScore()
    {
        _bestScore.text = Convert.ToString(Progress.Instance.BestScore);
    }
}
