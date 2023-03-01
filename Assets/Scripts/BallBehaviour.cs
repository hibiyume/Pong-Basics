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

    private Rigidbody2D _rigidbody2D;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
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
                break;
            case "LosingWallPlayer1":
                _rigidbody2D.velocity = Vector2.zero;
                _scoreBehaviour.IncreasePlayer2Score();
                break;
            case "LosingWallPlayer2":
                _rigidbody2D.velocity = Vector2.zero;
                _scoreBehaviour.IncreasePlayer1Score();
                break;
            case "Player":
                _rigidbody2D.velocity = -previousVelocity;

                Vector2 colPosition = col.transform.position;
                Vector2 playerPosition = transform.position;
                float heightDifference = playerPosition.y - colPosition.y;
                _rigidbody2D.velocity = new Vector2(-previousVelocity.x * speedScale, heightDifference * bounceAngleCoefficient);
                break;
        }
    }

    //Gives starting speed to the ball at the start of the game.
    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(1.5f);
        _rigidbody2D.velocity = new Vector2(-speed, 0f);
    }
}