using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    public float speed;
    [SerializeField] private float speedScale;
    [SerializeField] private float startingGameTime;
    [SerializeField] private float bounceAngleCoefficient;
    [SerializeField] private ScoreBehaviour _scoreBehaviour;
    private Vector2 previousVelocity;

    [SerializeField] public static AudioSource audioSource;
    [SerializeField] private AudioClip bounceSound;
    [SerializeField] private AudioClip player1ScoredSound;
    [SerializeField] private AudioClip player2ScoredSound;

    private Rigidbody2D _rigidbody2D;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(StartGame());
    }

    void FixedUpdate()
    {
        previousVelocity = _rigidbody2D.velocity;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        switch (col.gameObject.tag)
        {
            case "Wall":
                _rigidbody2D.velocity = new Vector2(previousVelocity.x, -previousVelocity.y);

                audioSource.clip = bounceSound;
                float prevPitch = audioSource.pitch;
                audioSource.pitch = 1f;
                audioSource.Play();
                audioSource.pitch = prevPitch;
                break;
            case "LosingWallPlayer1":
                _rigidbody2D.velocity = Vector2.zero;
                StartCoroutine(IncreasePlayerScore("Player2"));
                
                audioSource.clip = player2ScoredSound;
                prevPitch = audioSource.pitch;
                audioSource.pitch = 1f;
                audioSource.Play();
                audioSource.pitch = prevPitch;
                break;
            case "LosingWallPlayer2":
                _rigidbody2D.velocity = Vector2.zero;
                StartCoroutine(IncreasePlayerScore("Player1"));

                audioSource.clip = player1ScoredSound;
                prevPitch = audioSource.pitch;
                audioSource.pitch = 1f;
                audioSource.Play();
                audioSource.pitch = prevPitch;
                break;
            case "Player":
                _rigidbody2D.velocity = -previousVelocity;

                Vector2 playerPosition = col.transform.position;
                Vector2 ballPosition = transform.position;
                float heightDifference = ballPosition.y - playerPosition.y;
                _rigidbody2D.velocity = new Vector2(-previousVelocity.x * speedScale,
                    heightDifference * bounceAngleCoefficient);

                audioSource.clip = bounceSound;
                audioSource.pitch += 0.005f;
                audioSource.Play();
                break;
        }
    }

    //Gives starting speed to the ball at the start of the game.
    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(1.5f);
        _rigidbody2D.velocity = new Vector2(-speed, 0f);
    }

    IEnumerator IncreasePlayerScore(string player)
    {
        yield return new WaitUntil(() => !audioSource.isPlaying);
        if (player == "Player1")
        {
            _scoreBehaviour.IncreasePlayer1Score();
        }
        else if (player == "Player2")
        {
            _scoreBehaviour.IncreasePlayer2Score();
        }
    }
}