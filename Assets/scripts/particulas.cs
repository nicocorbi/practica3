using UnityEngine;

public class ParticlesFollowPlayer : MonoBehaviour
{
    public Transform player; // The transform of the player
    public Vector3 particleOffset = new Vector3(0, 1, 0); // Offset for the particle system's position relative to the player
    private ParticleSystem particleSystem; // Reference to the particle system

    void Start()
    {
        // Get the reference to the particle system
        particleSystem = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        // Update the position of the particle system to follow the player
        transform.position = player.position + particleOffset;
    }
}
