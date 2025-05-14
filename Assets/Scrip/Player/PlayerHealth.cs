using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public GameOverManager gameOverManager;

    public int maxHealth = 100;
    public int currentHealth;

    public Slider healthSlider;
    public GameObject gameOverPanel; // Kéo Panel từ Hierarchy vào

    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false); // Ẩn panel khi bắt đầu
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateHealthUI()
    {
        if (healthSlider != null)
            healthSlider.value = currentHealth;
    }

    void Die()
    {
        isDead = true;
        Debug.Log("Player Died!");
        if (gameOverManager != null)
        {
            gameOverManager.ShowGameOver();
        }

    }
}
