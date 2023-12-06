using System.Diagnostics;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackRange = 100f;
    public LayerMask enemyLayer;

    private bool isAttacking = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isAttacking)
        {
            PerformAttack();
        }
    }

    void PerformAttack()
    {
        isAttacking = true;

        // Detect enemies in range based on the enemy layer
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange, enemyLayer);

        // Check if any enemies were hit
        if (hitEnemies.Length > 0)
        {
            UnityEngine.Debug.Log("Attacked " + hitEnemies.Length + " enemies!");

            // Deal damage to each enemy
            foreach (Collider2D enemyCollider in hitEnemies)
            {
                if (enemyCollider != null)
                {
                    // Check if the enemy has an EnemyHealth component
                    EnemyHealth enemyHealth = enemyCollider.GetComponent<EnemyHealth>();

                    if (enemyHealth != null)
                    {
                        // Deal damage to the enemy
                        enemyHealth.TakeDamage(10);

                        // Indicate that damage is being dealt
                        UnityEngine.Debug.Log("Dealing damage to an enemy!");
                    }
                }
            }
        }
        else
        {
            UnityEngine.Debug.Log("No enemies in range.");
        }

        // Reset the attack state
        isAttacking = false;
    }


    void OnDrawGizmosSelected()
    {
        // Visualize the attack range in the Scene view
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
