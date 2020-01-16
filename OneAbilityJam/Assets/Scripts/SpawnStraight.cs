using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStraight : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _spawnRate;
    [SerializeField] private int _enemiesToSpawn;
    [SerializeField] private GameObject _enemy01Prefab;
    [SerializeField] private float minRandTime;
    [SerializeField] private float maxRandTime;
    [SerializeField] private float minRandPos;
    [SerializeField] private float maxRandPos;
    

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }
    
    private IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < _enemiesToSpawn; i++)
        {
            var randTime = Random.Range(minRandTime, maxRandTime);
            var randIndex = Random.Range(0, _spawnPoints.Length);
            var randX = Random.Range(minRandPos, maxRandPos); 
            var initPos = _spawnPoints[randIndex].position;
            var randPos = new Vector2(initPos.x + randX, initPos.y);
            Instantiate(_enemy01Prefab, randPos, Quaternion.identity);
            yield return new WaitForSeconds(1f/_spawnRate + randTime);
        }
    }
}
