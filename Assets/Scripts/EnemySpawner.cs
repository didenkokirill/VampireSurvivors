using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject spawnParticle;
    [SerializeField] private Vector2 spawnArea;
    [SerializeField] private float spawnDelay;
    [SerializeField] private Transform target;
    private float timer;
    private GameObject spawnParticleGO;

    private void Start()
    {
        SpawnEnemy(DefinitionPositin());
    }

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
        spawnParticleGO = Instantiate(spawnParticle, pos, Quaternion.identity);

        yield return new WaitForSeconds(2); // wait to spawn enemy

        Destroy(spawnParticleGO);

        SpawnEnemy(pos);
    }
    private void SpawnEnemy(Vector3 pos)
    {        
        GameObject newEnemy = Instantiate(enemy, pos, Quaternion.identity);
        newEnemy.GetComponent<MoveEnemy>().target = target;
    }
}
