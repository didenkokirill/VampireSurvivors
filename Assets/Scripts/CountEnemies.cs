using System.Collections.Generic;
using UnityEngine;

public class CountEnemies : MonoBehaviour
{ 
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
