using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    [SerializeField] float speed = 0f;
    [SerializeField] public Transform player;
    [SerializeField] public int damage = 10;
    [SerializeField] public int fleeSpeed = 2;
    

    private float length = 0;
    private Vector3 normalizedDirection;

    public GameObject respawnPrefab;
    public GameObject[] respawns;

    void Start()
    {
        if (player == null)
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            if (playerObject != null)
            {
                player = playerObject.transform;
            }
           
        }

        if (respawns == null)
        {
            respawns = GameObject.FindGameObjectsWithTag("Enemy");
        }
    }

    void Update()
    {
        if (player.GetComponent<Health>().isPlayerDead)
        {
            Vector3 direction = (transform.position -= normalizedDirection * speed * Time.deltaTime * fleeSpeed);
        }
        else
        {
            Vector3 direction = (player.position - transform.position);
            length = Mathf.Sqrt((direction.x * direction.x + direction.y * direction.y));

            normalizedDirection = direction / length;
            UpdatePosition();
        }
    }

    void UpdatePosition()
    {
        transform.position += normalizedDirection * speed * Time.deltaTime;
    }
}
