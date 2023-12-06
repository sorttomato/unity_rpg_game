using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UnityEngine.Debug.Log("Enemy health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Handle death logic, e.g., play death animation, destroy GameObject, etc.
        UnityEngine.Debug.Log("Enemy died!");
        Destroy(gameObject);
    }
}
