using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextBehaviour : MonoBehaviour
{
    public TextMeshProUGUI myText;
    private int textNumber = 0;
    
    void Start()
    {
        myText.text = textNumber < 10 ? $"0{textNumber}" : textNumber.ToString();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
        }
    }
}
