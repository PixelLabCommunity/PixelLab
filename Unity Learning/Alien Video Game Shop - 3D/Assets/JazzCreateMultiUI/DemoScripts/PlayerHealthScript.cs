using UnityEngine;
using System.Collections;
using UnityEngine.UI; // needed for scripting to Unity UI elements
using UnityEngine.SceneManagement;


[RequireComponent(typeof(BoxCollider2D))] // makes sure player has a collider for collision detection.

public class PlayerHealthScript : MonoBehaviour
{
    public Image heartFill;
    public float maxHealth = 100f;
    public float currentHealth = 0f;

    private BoxCollider2D bc2D;

    void Start ()
    {
        bc2D = GetComponent<BoxCollider2D>();
        currentHealth = maxHealth;
        bc2D.isTrigger = true;
    }

    void TakeHealth()
    {
        currentHealth -= 10f;
        float healthEquals = currentHealth / maxHealth;
        SetHealth(healthEquals);
    }

    void SetHealth(float healthAmount)
    {
        heartFill.fillAmount = healthAmount;
        if(healthAmount <= 0)
        {
            SceneManager.LoadScene(0);
            // Application.LoadLevel(0); Old Unity Code, now obselete...
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            TakeHealth();
            other.gameObject.SetActive(false);
        }
    }
}
