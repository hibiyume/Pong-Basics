using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreBehaviour : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI player1ScoreText;
    [SerializeField] private TextMeshProUGUI player2ScoreText;

    [SerializeField] private Transform player1Transform;
    private static readonly Vector2 player1DefaultPosition = new Vector2(-7.25f, -0.4f);
    [SerializeField] private Transform player2Transform;
    private static readonly Vector2 player2DefaultPosition = new Vector2(7.25f, -0.4f);
    [SerializeField] private GameObject ball;
    private static readonly Vector2 ballDefaultPosition = new Vector2(-1f, -0.4f);

    [SerializeField] private AudioClip player1WonSound;
    [SerializeField] private AudioClip player2WonSound;
    
    private const int ScoresToWin = 5;

    void Start()
    {
        player1ScoreText.text = GameManager.Player1Score.ToString();
        player2ScoreText.text = GameManager.Player2Score.ToString();
    }

    IEnumerator ResetGameField()
    {
        ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        BallBehaviour.audioSource.pitch = 1f;
        
        yield return new WaitForSeconds(1.5f);
        ball.transform.position = ballDefaultPosition;
        
        yield return new WaitForSeconds(1.5f);
        ball.GetComponent<Rigidbody2D>().velocity = new Vector2(-ball.GetComponent<BallBehaviour>().speed, 0f);
    }
    
    public bool IncreasePlayer1Score() // returns if won
    {
        GameManager.Player1Score++;
        player1ScoreText.text = GameManager.Player1Score.ToString();

        if (GameManager.Player1Score == ScoresToWin)
        {
            GameOverController.winnerPlayer = "Player1";
            BallBehaviour.audioSource.clip = player1WonSound;
            BallBehaviour.audioSource.Play();
            StartCoroutine(ChangeScene(2)); //Game over
            return true;
        }
        else
        {
            StartCoroutine(ResetGameField());
            return false;
        }
    }

    public bool IncreasePlayer2Score() // returns if won
    {
        GameManager.Player2Score++;
        player2ScoreText.text = GameManager.Player2Score.ToString();

        if (GameManager.Player2Score == ScoresToWin)
        {
            GameOverController.winnerPlayer = "Player2";
            BallBehaviour.audioSource.clip = player2WonSound;
            BallBehaviour.audioSource.Play();
            StartCoroutine(ChangeScene(2)); //Game over
            return true;
        }
        else
        {
            StartCoroutine(ResetGameField());
            return false;
        }
    }

    IEnumerator ChangeScene(int id)
    {
        yield return new WaitForSeconds(BallBehaviour.audioSource.clip.length);
        SceneManager.LoadScene(2);
    }
}