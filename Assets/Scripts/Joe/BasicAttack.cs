using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : MonoBehaviour
{
    public CharacterController controller2;
    public Animator animator;

    public float attackRate = 2f;
    float nextAttackTime = 0f;
    float lastTap = 0f;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetAxisRaw("Horizontal") == 0)
            {
                if (Input.GetKeyDown(KeyCode.C))
                {
                    Attack();
                    nextAttackTime = Time.time + 1f / attackRate;
                }
            }
        }
        else
        {
            AttackFollowUp();
        }
    }

    void Attack()
    {
        animator.SetTrigger("Hit_1");
        lastTap = Time.time;
    }

    void AttackFollowUp()
    {
        if (Input.GetKeyDown(KeyCode.C) && (lastTap + 0.5f >= Time.time))
        {
            animator.SetTrigger("Hit_2");
        }
    }
}
