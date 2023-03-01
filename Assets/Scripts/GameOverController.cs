using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI winningText;
    
    public static string winnerPlayer;

    void Start()
    {
        if (winnerPlayer == "Player1")
            winningText.text = "Player 1 has won!";
        else
            winningText.text = "Player 2 has won!";
    }
}
