using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] TMP_Text gameOverUI;
    [SerializeField] GameObject enemyUI;
    [SerializeField] TMP_Text maxHealthUI;
    [SerializeField] public int maxHealth = 100;
    [SerializeField] public Transform player;
    [SerializeField] public bool isPlayerDead = false;
    [SerializeField] public Image healthBar;

    private int currentHealth;

    private void Start()
    {
        // Initialize health and update the health bar
        currentHealth = maxHealth;
        UpdateHealthBar(); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with an object tagged as "Enemy"
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Reduce health by the damage dealt by the enemy
            currentHealth -= collision.gameObject.GetComponent<Enemy1>().damage;
            currentHealth = Mathf.Max(currentHealth, 0); // Ensure health doesn't drop below 0
        }

        // Check if the player has died
        if (currentHealth <= 0)
        {
            gameOverUI.gameObject.SetActive(true);
            isPlayerDead = true;
        }

        UpdateHealthUI();
    }

    void UpdateHealthUI()
    {
        // Update the health UI text
        maxHealthUI.text = currentHealth.ToString();
        print(currentHealth);

        // Update the health bar
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            // Calculate health percentage
            float healthPercentage = (float)currentHealth / maxHealth;

            // Update the health bar fill amount
            healthBar.fillAmount = Mathf.Clamp01(healthPercentage);
        }
    }
}

           
