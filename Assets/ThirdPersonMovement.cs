using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
<<<<<<< HEAD

=======
    
>>>>>>> b7546f80695fdbc30557c4cf27f8f94bae812e1c
    public CharacterController controller;

    public Transform cam;

    public float speed = 6f;

    public float gravity = 9.81f;
    public float jumpHeight = 3;
    Vector3 velocity;
<<<<<<< HEAD

    bool isGrounded;
=======
    bool isGrounded;

>>>>>>> b7546f80695fdbc30557c4cf27f8f94bae812e1c
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

<<<<<<< HEAD

    public float jumpCoolDown = 2f;
    public float timeSinceJump = 0.0f;

=======
>>>>>>> b7546f80695fdbc30557c4cf27f8f94bae812e1c
    public float turnSmoothTime = 0.1f;

    public float turnSmoothVelocity;


    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD

        timeSinceJump += Time.deltaTime;

=======
>>>>>>> b7546f80695fdbc30557c4cf27f8f94bae812e1c
        //jump
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)

        {
            velocity.y = -2f;
<<<<<<< HEAD

=======
>>>>>>> b7546f80695fdbc30557c4cf27f8f94bae812e1c
        }

        if (Input.GetButtonDown("Jump") && isGrounded)

        {
<<<<<<< HEAD
            if (timeSinceJump > jumpCoolDown)
            {
                timeSinceJump = 0;
                velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            }

        }

=======
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
>>>>>>> b7546f80695fdbc30557c4cf27f8f94bae812e1c
        //gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward; ;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
    }
}
