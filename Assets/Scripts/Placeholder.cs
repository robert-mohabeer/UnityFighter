using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placeholder: MonoBehaviour
{
    public CharacterController controller;
    public Animator animator;
    public float speed = 6f;
    public float weight = 10;
    public float jump = 10;
    public float distToGround = 1f;

    private float vVelocity;
    static float right = 0;
    static float left = 180;

    Vector3 direction;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        //assigns direction based on player position
        float playerDirection = right;
        if (this.transform.eulerAngles.y == 180 || this.transform.eulerAngles.y == -180)
        {
            playerDirection = left;
        }

        //when the player presses arrow keys or WASD, the character will move along the z or y axis

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        //direction = new Vector3(0f, vertical, horizontal).normalized;
        direction.z = horizontal;

        //triggers the walk animation
        if (horizontal != 0)
        {
            WalkingAnimation(true);
        }

        //Turns player model towards a new direction if necessary
        if (horizontal < 0f && playerDirection == right)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            FlipAnimation();
        }
        else if (horizontal > 0f && playerDirection == left)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            FlipAnimation();
        }

        //moves the player along the direction vector
        if (direction.magnitude >= 0.1f)
        {
            controller.Move(direction * speed * Time.deltaTime);
        }

        //triggers the walk animation
        if (horizontal == 0)
        {
            WalkingAnimation(false);
        }


        gravityHandler(vertical, horizontal);
    }

    void WalkingAnimation(bool value)
    {
        animator.SetBool("Move", value);
    }

    void FlipAnimation()
    {
        animator.SetTrigger("Flip");
    }

    //handles jumping
    void gravityHandler(float v, float h)
    {
        if (grounded())
        {
            //Debug.Log("jumpable");
            vVelocity = -weight * Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                vVelocity = jump;
                //direction.y = jump;
                //direction = new Vector3(0, jump, h / 2);
            }
        }
        else
        {
            //Debug.Log("fall as all mortals must");
            vVelocity -= weight * Time.deltaTime;
            //direction.y -= weight * Time.deltaTime;
            //direction = new Vector3(0, direction.y - weight * Time.deltaTime, h / 2);
            //direction *= Time.deltaTime;
        }
        direction = new Vector3(0, vVelocity, 0);

    }

    //checks if grounded and what ground type
    bool grounded()
    {
        if (Physics.Raycast(transform.position, Vector3.down, distToGround + 0.1f))
        {
            Debug.Log("grounded" + groundType());
            return true;
        }
        Debug.Log("not grounded");
        return false;


    }

    string groundType()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, Vector3.down, out hit, distToGround + 0.1f);
        return hit.transform.name;
    }
}
