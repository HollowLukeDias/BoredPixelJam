using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float _padding = 1f;
    [SerializeField] private float _health = 100;
    private Rigidbody2D rb;
    private float _moveX;
    private float _moveY;
    
    private float _xMin;
    private float _xMax;
    private float _yMin;
    private float _yMax;
    
    
    private void Start()
    {
        SetUpMoveBoundaries();
        rb = GetComponent<Rigidbody2D>();
    }
    private void SetUpMoveBoundaries()
    {
        var gameCamera = Camera.main;
        _xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + _padding;
        _xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - _padding;
        _yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + _padding;
        _yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - _padding;
    }
    void Update()
    {
        _moveX = Input.GetAxis("Horizontal");
        _moveY = Input.GetAxis("Vertical");
    }
    private void Mover()
    {
        var deltaX = _moveX * Time.deltaTime * speed;
        var deltaY = _moveY * Time.deltaTime * speed;
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, _xMin, _xMax);
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, _yMin, _yMax);
        rb.MovePosition(new Vector2(newXPos, newYPos));

    }
    private void FixedUpdate()
    {
        Mover();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            var damage = other.GetComponent<EnemyShip>().Damage;
            ProcessHit(damage);
        }
    }

    private void ProcessHit(float damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Debug.Log("GameOver");
        }
    }
}
