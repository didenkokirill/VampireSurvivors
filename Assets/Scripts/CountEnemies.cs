using System.Collections.Generic;
using UnityEngine;

public class CountEnemies : MonoBehaviour
{ 
    public static CountEnemies Instance;

    private void Awake() => Instance = this;

    [SerializeField] private List<GameObject> enemyList = new();

    public void Add(GameObject enemy)
    {
        enemyList.Add(enemy);
    }
    public void Remove(GameObject enemy)
    {
        enemyList.Remove(enemy);
    }
    public int Count()
    {
        return enemyList.Count;
    }
    public List<GameObject> List()
    {
        return enemyList;
    }
}
