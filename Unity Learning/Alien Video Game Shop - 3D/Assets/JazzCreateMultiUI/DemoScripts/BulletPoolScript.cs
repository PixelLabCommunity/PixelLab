using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletPoolScript : MonoBehaviour
{

    public static BulletPoolScript current_BulletPool;
    public GameObject bulletPrefab;
    public int pooledAmount = 10;
    public bool willGrow = true;

    List<GameObject> bulletPrefabs;

    void Awake()
    {
        current_BulletPool = this;
    }

    void Start()
    {
        bulletPrefabs = new List<GameObject>();
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(bulletPrefab);
            obj.SetActive(false);
            bulletPrefabs.Add(obj);
        }
    }

    public GameObject GetBulletObject()
    {
        for (int i = 0; i < bulletPrefabs.Count; i++)
        {
            if (!bulletPrefabs[i].activeInHierarchy)
            {
                return bulletPrefabs[i];
            }
        }
        if (willGrow)
        {
            GameObject obj = (GameObject)Instantiate(bulletPrefab);
            bulletPrefabs.Add(obj);
            return obj;
        }
        return null;
    }
}
