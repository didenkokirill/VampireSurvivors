using System.Collections.Generic;
using UnityEngine;

public class FindNearest : MonoBehaviour
{
    [SerializeField] private CountEnemies countEnemys;
    private GameObject target;
    private List<GameObject> targets;
    public GameObject nearest;

    private void Awake()
    {
        targets = countEnemys.List(); 
    }
    private GameObject FindClosestEnemy()
    {
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;

        if (targets == null)
        {
            return null;
        }
        foreach (GameObject enemy in targets) 
        {
            Vector3 diff = enemy.transform.position - position;
            float curDistance = diff.sqrMagnitude;

            if (curDistance < distance)
            {
                target = enemy;
                distance = curDistance;
            }
        }

        return target;
    }

    private void Update()
    {
        nearest = FindClosestEnemy();

    }
}
