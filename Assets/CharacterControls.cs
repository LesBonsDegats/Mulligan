using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]

public class CharacterControls : MonoBehaviour
{

    public float speed = 8.0f;
    public float gravity = 10.0f;
    public float maxVelocityChange = 10.0f;
    public bool canJump = true;
    public float jumpHeight = 14.0f;
    private bool grounded = false;
    public Rigidbody r;


    void Awake()
    {
        r.freezeRotation = true;
        r.useGravity = false;
    }

    void FixedUpdate()
    {
        if (grounded)
        {
            // Calculate how fast we should be moving
            Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            targetVelocity = transform.TransformDirection(targetVelocity);


            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                speed *= 10;
            }

            targetVelocity *= speed;
         

            // Apply a force that attempts to reach our target velocity
            Vector3 velocity = r.velocity;
            Vector3 velocityChange = (targetVelocity - velocity);

            speed = 8;


            if (canJump && Input.GetButton("Jump"))
            {
                r.velocity = new Vector3(velocity.x / 1.2f, CalculateJumpVerticalSpeed(), velocity.z/1.2f);
            }
            else
            {
                r.AddForce(velocityChange, ForceMode.VelocityChange);
            }
        

            
        }

        // We apply gravity manually for more tuning control
        r.AddForce(new Vector3(0, -gravity * r.mass, 0));

        grounded = false;
    }

    void OnCollisionStay()
    {
        grounded = true;
    }

    float CalculateJumpVerticalSpeed()
    {
        // From the jump height and gravity we deduce the upwards speed 
        // for the character to reach at the apex.
        return Mathf.Sqrt(2 * jumpHeight * gravity);
    }
}