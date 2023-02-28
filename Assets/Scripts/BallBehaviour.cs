using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float startingGameTime;
    [SerializeField] private float bounceAngleCoefficient;
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

    void OnCollisionEnter2D(Collision2D col) // TODO adjust movement to speed
    {
        switch (col.gameObject.tag)
        {
            case "Wall":
                _rigidbody2D.velocity = new Vector2(previousVelocity.x, -previousVelocity.y);
                break;
            case "LosingWallPlayer1":
                //TODO player1 has lost
                break;
            case "LosingWallPlayer2":
                //TODO player2 has lost
                break;
            case "Player":
                _rigidbody2D.velocity = -previousVelocity;

                Vector2 colPosition = col.transform.position;
                Vector2 playerPosition = transform.position;
                float heightDifference = playerPosition.y - colPosition.y;
                _rigidbody2D.velocity = new Vector2(-previousVelocity.x, heightDifference * bounceAngleCoefficient);
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