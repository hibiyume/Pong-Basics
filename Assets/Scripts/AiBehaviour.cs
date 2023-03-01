using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiBehaviour : MonoBehaviour
{
    [SerializeField] private Transform ballTransform; // AI uses ball position to move its racket

    [SerializeField] private float speed;
    private const float MinClamp = -2.9f;
    private const float MaxClamp = 2.15f;

    private Rigidbody2D _rigidbody2D;
    private Transform _transform;


    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
    }

    void Update()
    {
        _rigidbody2D.velocity = Vector2.zero;
        _transform.position = new Vector2(_transform.position.x,
            Mathf.Clamp(ballTransform.position.y, _transform.position.y - (speed * Time.deltaTime),
                _transform.position.y + (speed * Time.deltaTime)));
        //_rigidbody2D.velocity = new Vector2(0f, -speed);


        Vector2 clampedPosition = _transform.position;
        clampedPosition.y = Mathf.Clamp(_transform.position.y, MinClamp, MaxClamp);
        _transform.position = clampedPosition;
    }
}