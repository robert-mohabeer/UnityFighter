using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slam_Attack : MonoBehaviour
{
    public CharacterController controller3;
    public Animator animator;

    public float attackRate = 1f;
    float nextAttackTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            //Do slam animation
            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                if (Input.GetKeyDown(KeyCode.C))
                {
                    doSlam();
                    nextAttackTime = Time.time + 1f / attackRate;
                }
            }
        }
    }

    void doSlam()
    {
        animator.SetTrigger("Slam");
    }


}
