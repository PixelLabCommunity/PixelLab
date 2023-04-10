using UnityEngine;
using System.Collections;

public class SpawnEnemies : MonoBehaviour
{
    public float spawnCD = 0.5f;
    public float spawnCDremaining = 3f;

    public GameObject enemy;
    private Vector2 startPos;
	
	void Start ()
    {
        InvokeRepeating("LaunchEnemy", spawnCD, spawnCDremaining);
       // InvokeRepeating("EnemySpawn", 3f, 8f);
	}
	
	void EnemySpawn ()
    {
	Vector2 startPos = new Vector2(Random.Range(-6,6),Random.Range(4,5));
        Instantiate(enemy, startPos, transform.rotation);
	}

void LaunchEnemy()
{
    GameObject obj = EnemyPoolScript.current_EnemyPool.GetEnemyObject();

    if (obj == null) return;
    obj.transform.position = new Vector2(Random.Range(-6, 6), Random.Range(4, 5));
    //obj.transform.position = this.transform.position;
    obj.transform.rotation = this.transform.rotation;
    obj.SetActive(true);
    // break;
    }
}
