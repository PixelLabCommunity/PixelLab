using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyPoolScript : MonoBehaviour
{
    public static EnemyPoolScript current_EnemyPool;
    public GameObject enemyPrefab;
    public int pooledAmount = 10;
    public bool willGrow = true;

    List<GameObject> enemyPrefabs;

    void Awake()
    {
        current_EnemyPool = this;
    }

    // Use this for initialization
    void Start()
    {
        enemyPrefabs = new List<GameObject>();
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(enemyPrefab);
            obj.SetActive(false);
            enemyPrefabs.Add(obj);
        }
    }

    public GameObject GetEnemyObject()
    {
        for (int i = 0; i < enemyPrefabs.Count; i++)
        {
            if (!enemyPrefabs[i].activeInHierarchy)
            {
                return enemyPrefabs[i];
            }
        }
        if (willGrow)
        {
            GameObject obj = (GameObject)Instantiate(enemyPrefab);
            enemyPrefabs.Add(obj);
            return obj;
        }
        return null;
    }
}
