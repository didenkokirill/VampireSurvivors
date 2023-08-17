using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float spawnDelay;
    [SerializeField] private float waitToSpawn;

    [SerializeField] private Vector2 spawnArea;

    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject spawnParticle;  
    [SerializeField] private Transform target;

    private float timer;
    private GameObject spawnParticleGO;

    private void FixedUpdate()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            StartCoroutine(SpawnEnemyDelayed());
            timer = spawnDelay; 
        }
    }

    private Vector3 DefinitionPositin()
    {
        Vector3 position = new Vector3(
            Random.Range(-spawnArea.x, spawnArea.x),
            Random.Range(-spawnArea.y, spawnArea.y),
            0f);

        return (position);
    }
    private IEnumerator SpawnEnemyDelayed()
    {
        Vector3 pos = DefinitionPositin();
        GameObject spawnParticleGO = Instantiate(spawnParticle, pos, Quaternion.identity); 

        yield return new WaitForSeconds(waitToSpawn);

        Destroy(spawnParticleGO);

        SpawnEnemy(pos);
    }
    private void SpawnEnemy(Vector3 pos)
    {        
        GameObject newEnemy = Instantiate(enemy, pos, Quaternion.identity);
        MoveEnemy moveEnemy = newEnemy.GetComponent<MoveEnemy>();
        moveEnemy.target = target;
        moveEnemy.damage = damage;
        CountEnemies.Instance.Add(newEnemy);
    }
}
