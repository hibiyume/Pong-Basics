using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounterButtonBehaviour : MonoBehaviour
{
    public TextMeshProUGUI scoreCounter;
    private int textNumber = 0;

    private void Start()
    {
        scoreCounter.text = textNumber < 10 ? $"0{textNumber}" : textNumber.ToString();
    }

    public void OnButtonPressed()
    {
        textNumber++;
        scoreCounter.text = textNumber < 10 ? $"0{textNumber}" : textNumber.ToString();
    }
}