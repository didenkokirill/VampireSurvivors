using UnityEngine;

public class FindNearest : MonoBehaviour
{
    [SerializeField] private GameObject[] enemy;
    private GameObject target;

    [SerializeField] public GameObject nearest;

    private GameObject FindClosestEnemy()
    {
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in enemy)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;

            if (curDistance < distance)
            {
                target = go;
                distance = curDistance;
            }
        }

        if (target != null)
        {
            return target;
        }

        else
        {
            return null;
        }
    }

    private void FixedUpdate()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        nearest = FindClosestEnemy();      
    }
}
