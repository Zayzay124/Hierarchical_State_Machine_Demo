using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private float xInput;
    private float yInput;
    private Vector2 inputDir;

    public Animator animator;

    public float startSpeed;
    public float maxSpeed;
    public InputActionReference space;

    //Debuging stuff remove later
    public Entity enemy;

    public Rigidbody2D rb;

    public HitboxComponent swingHitbox;

    private bool attacking = false;

    void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");

        inputDir = new Vector2(xInput, yInput).normalized;
    }

    void FixedUpdate()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        if (attacking)
        {
            return;
        }

        if (inputDir == Vector2.zero)
        {
            rb.linearVelocity = Vector2.zero;
        }
        else
        { // the start up is mostly unnoticable
            rb.linearVelocityX += xInput * startSpeed;
            rb.linearVelocityY += yInput * startSpeed;
            rb.linearVelocity = Vector2.ClampMagnitude(rb.linearVelocity, maxSpeed);
        }
    }

    public void DealDamage(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            enemy.TakeDamage(5);
            Debug.Log("ouch");
        }
    }

    public void Swing(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            attacking = true;
            swingHitbox.Activate();
        }
    }

}