using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private Vector2 spawnArea;
    [SerializeField] private float spawnSpeed;
    [SerializeField] private Transform target;
    private float timer;

    private void FixedUpdate()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            SpawnEnemy();
            timer = spawnSpeed; 
        }
    }
    private void SpawnEnemy()
    {
        Vector3 position = new Vector3(
            Random.Range(-spawnArea.x, spawnArea.x),
            Random.Range(-spawnArea.y, spawnArea.y),
            0f);
        GameObject newEnemy = Instantiate(enemy);
        newEnemy.transform.position = position;
        newEnemy.GetComponent<MoveEnemy>().target = target;
    }
}
