using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))] // makes sure enemy has a collider for collision detection.
public class EnemyScript : MonoBehaviour
{
    public GameObject ufoLights01;
    public GameObject ufoLights02;
    public float enemySpeed = 0.1f;
    private Rigidbody2D rb2D;
    private BoxCollider2D bc2D;

	void Start ()
    {
        ufoLights01.GetComponent<SpriteRenderer>().color = Color.red;
        ufoLights02.GetComponent<SpriteRenderer>().color = Color.green;
        bc2D = GetComponent<BoxCollider2D>();
        rb2D = GetComponent<Rigidbody2D>();
        bc2D.isTrigger = false;
    }
   
	
	void FixedUpdate ()
    {
        rb2D.velocity = new Vector2(0f, transform.localScale.y * -enemySpeed);
	}

    void OnCollisionEnter2D (Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            this.gameObject.SetActive(false);
        }
    }
}
