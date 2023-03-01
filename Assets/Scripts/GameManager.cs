using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int Player1Score { get; set; }
    public static int Player2Score { get; set; }

    void Awake()
    {
        Player1Score = 0;
        Player2Score = 0;
    }
}
