using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour
{
    public Transform gunTip;
    public Rigidbody2D bullet;
    public float bulletSpeed = 5f;

    void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            FireBullet();
        }
    }

    void FireBullet()
    {
        GameObject obj = BulletPoolScript.current_BulletPool.GetBulletObject();

        if (obj == null) return;
        obj.transform.position = gunTip.transform.position;
        obj.transform.rotation = this.transform.rotation;
        obj.SetActive(true);
        obj.GetComponentInChildren<Rigidbody2D>().velocity = new Vector2(0f, bulletSpeed);

    }

}
