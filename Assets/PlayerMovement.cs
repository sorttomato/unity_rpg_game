using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private enum MovementState { idle, running }

    private Rigidbody2D rb;
    private float MovementSpeed = 4f;
    private Animator anim;
    private float dirX;
    private float dirY;

    private Vector2 lastDirection = Vector2.down;  // Default direction is down for idle state

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

        rb.velocity = new Vector2(dirX * MovementSpeed, dirY * MovementSpeed);
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

        if (dirX == 0f && dirY == 0f)
        {
            state = MovementState.idle;
        }
        else
        {
            state = MovementState.running;
            lastDirection = new Vector2(dirX, dirY).normalized;
        }

        anim.SetFloat("BlendX", lastDirection.x);
        anim.SetFloat("BlendY", lastDirection.y);
        anim.SetInteger("State", (int)state);
    }
}
