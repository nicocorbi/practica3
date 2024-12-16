using UnityEngine;

public class Points : MonoBehaviour
{
    public Vector2 minBounds; 
    public Vector2 maxBounds; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object that entered the trigger has the "Player" tag
        if (other.CompareTag("Player"))
        {
            // Generate a random position within the defined bounds
            float randomX = Random.Range(minBounds.x, maxBounds.x);
            float randomY = Random.Range(minBounds.y, maxBounds.y);

            // Update the position of the object to the new random position
            transform.position = new Vector2(randomX, randomY);
        }
    }
}
