using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))] //makes sure the bullet prefab has a rigidbody attached.
[RequireComponent(typeof(BoxCollider2D))] // makes sure bullet has a collider for collision detection.

public class BulletDestroy : MonoBehaviour
{ 
	
	void OnCollisionEnter2D (Collision2D col)
    {
	if(col.gameObject.tag == "Enemy" )
        {
            this.gameObject.SetActive(false);
        }
	}
}
