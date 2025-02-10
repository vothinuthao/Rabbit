using System.Collections;
using System.Collections.Generic;
using Runtime.GamePlay.Manager;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    private int currentHealth;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;


    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    // Update is called once per frame

    public void TakeDamage(int damage = 1)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damage;
            UpdateHealthUI();
            if (currentHealth <= 0)
            {
                Die();
            }
        }

    }
    
    private void UpdateHealthUI()
    {
            for (int i = 0; i < hearts.Length; i++)
            {
                if (i < currentHealth)
                {
                    hearts[i].sprite = fullHeart; // Hiển thị trái tim đầy
                }
                else
                {
                    hearts[i].sprite = emptyHeart; // Hiển thị trái tim trống
                }
                hearts[i].enabled = true;
            }
    }
    

    private void Die()
    {
        GameManager.Instance.EndLevel(false);
    }

}
