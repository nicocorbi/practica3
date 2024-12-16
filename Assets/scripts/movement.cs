using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float speed = 0f;
    public Transform player;
    
    private Health healthScript; 

    void Start()
    {
        // Initialize the health script
        healthScript = gameObject.GetComponent<Health>();

        // Set the initial position of the player
        player.transform.position = new Vector3(0, 0, 0);
    }

    void Update()
    {
        // If the player is dead, exit the function
        if (healthScript.isPlayerDead) 
        {
            return;
        }

        // Move the player to the right
        if (Input.GetKey(KeyCode.D))
        {
            player.transform.position += Vector3.right * speed * Time.deltaTime;
        }

        // Move the player to the left
        if (Input.GetKey(KeyCode.A))
        {
            player.transform.position += Vector3.left * speed * Time.deltaTime;
        }

        // Move the player downward
        if (Input.GetKey(KeyCode.S))
        {
            player.transform.position += Vector3.down * speed * Time.deltaTime;
        }

        // Move the player upward
        if (Input.GetKey(KeyCode.W))
        {
            player.transform.position += Vector3.up * speed * Time.deltaTime;
        }
    }
}
