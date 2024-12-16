using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] public Transform player;
    public Transform spawn;

    float elapsedTime = 0;
    [SerializeField] public int spawnInterval = 5;

    void Start()
    {
        Spawn(); 
    }

    void Update()
    {
        // Increment elapsed time
        elapsedTime += Time.deltaTime;

        // Check if the elapsed time exceeds the spawn interval
        if (elapsedTime >= spawnInterval)
        {
            // Reset prefab position (optional, depending on logic)
            prefab.transform.position = new Vector3(0, 0, 0);
            elapsedTime = 0; // Reset elapsed time
            Spawn(); // Spawn a new enemy
            print(elapsedTime);
        }

        print(elapsedTime);
    }

    void Spawn()
    {
        // Instantiate the enemy prefab at the spawn point
        GameObject.Instantiate(prefab, GameObject.FindGameObjectWithTag("spawn").transform.position, Quaternion.identity);
    }
}
