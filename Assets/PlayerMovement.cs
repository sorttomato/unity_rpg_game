using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private enum MovementState { up, down, left, right }
    private Rigidbody2D rb;
    private float MoventSpeed = 4f;
    private Animator anim;
    float dirX;
    float dirY;

    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
       
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxis("Horizontal");
        dirY = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(dirX * MoventSpeed, dirY * MoventSpeed);
        UpdateAnimationState();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }


    private void UpdateAnimationState()
    {
        MovementState state;
        if (Mathf.Abs(dirX) > Mathf.Abs(dirY))
        {
            if (dirX > 0f)
            {
                state = MovementState.right;
            }
            else
            {
                state = MovementState.left;
            }
        }
        else
        {
            if (dirY > 0f)
            {
                state = MovementState.up;
            }
            else
            {
                state = MovementState.down;
            }
        }
        anim.SetInteger("state", (int)state);
    }
}