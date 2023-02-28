using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreBehaviour : MonoBehaviour
{
    [SerializeField] private static TextMeshProUGUI player1ScoreText;
    [SerializeField] private static TextMeshProUGUI player2ScoreText;

    [SerializeField] private Transform player1Transform;
    private static readonly Vector2 player1DefaultPosition = new Vector2(-7.25f, -0.4f);
    [SerializeField] private Transform player2Transform;
    private static readonly Vector2 player2DefaultPosition = new Vector2(7.25f, -0.4f);
    [SerializeField] private Transform ballTransform;
    private static readonly Vector2 ballDefaultPosition = new Vector2(-1f, -0.4f);

    private const int ScoresToWin = 5;

    void Start()
    {
        player1ScoreText.text = GameManager.Player1Score.ToString();
        player2ScoreText.text = GameManager.Player2Score.ToString();
    }

    IEnumerator ResetGameField()
    {
        GameManager.IsInputEnabled = false;
        yield return new WaitForSeconds(1.5f);
        player1Transform.position = player1DefaultPosition;
        player2Transform.position = player2DefaultPosition;
        ballTransform.position = ballDefaultPosition;
        GameManager.IsInputEnabled = true;
    }
    
    public void IncreasePlayer1Score()
    {
        GameManager.Player1Score++;
        player1ScoreText.text = GameManager.Player1Score.ToString();

        if (GameManager.Player1Score == ScoresToWin)
            SceneManager.LoadScene(2); //Game over
    }
    
    public void IncreasePlayer2Score()
    {
        GameManager.Player2Score++;
        player2ScoreText.text = GameManager.Player2Score.ToString();
        if (GameManager.Player2Score == ScoresToWin)
            SceneManager.LoadScene(2); //Game over
    }
}