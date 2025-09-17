using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float xInput;
    private float yInput;
    private Vector2 inputDir;

    public float startSpeed;
    public float maxSpeed;


    public Rigidbody2D rb;

    void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");

        inputDir = new Vector2(xInput, yInput).normalized;
    }

    void FixedUpdate()
    {

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
}