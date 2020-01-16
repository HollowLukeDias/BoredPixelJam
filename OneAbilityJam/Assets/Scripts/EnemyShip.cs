using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    [SerializeField] private GameObject DeathFX;
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    private float _yMin;
    
    public float Damage => damage;
    
    private void Start()
    {
        var gameCamera = Camera.main;
        _yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
    }
    private void Update()
    {
        StraightMove();
    }

    private void StraightMove()
    {
        var move = speed * Time.deltaTime;
        transform.position = new Vector2(transform.position.x, transform.position.y - move);
        if (transform.position.y <= _yMin - 1f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var FX = Instantiate(DeathFX, transform.position, Quaternion.identity);
        Destroy(FX, 1f);
        Destroy(gameObject);
    }
}
