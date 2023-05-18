using UnityEngine;

public class PlayerColor : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        // Generate random color values
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);

        // Set the random color to the player sprite renderer
        _spriteRenderer.color = new Color(r, g, b);
    }
}
