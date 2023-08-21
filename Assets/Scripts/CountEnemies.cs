using System.Collections.Generic;
using UnityEngine;

public class CountEnemies : MonoBehaviour
{ 
    public static CountEnemies Instance;

    private void Awake() => Instance = this;

    [SerializeField] private List<GameObject> enemiesList = new();

    public void Add(GameObject enemy)
    {
        enemiesList.Add(enemy);
    }
    public void Remove(GameObject enemy)
    {
        enemiesList.Remove(enemy);
    }
    public int Count()
    {
        return enemiesList.Count;
    }
    public List<GameObject> List()
    {
        return enemiesList;
    }
    public void ResetEnemy()
    {
        foreach (GameObject enemy in enemiesList)
        {
            Destroy(enemy);
        }
        enemiesList.Clear();
    }
}
