using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    private NavMeshAgent agent;
    private Animator animator;
    private bool detected = false;

    public Transform Player;
    public float attackRange = 2f;
    public float detectionRange = 10f;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, Player.position);

            if (distanceToPlayer <= detectionRange)
            {
                detected = true;
                animator.SetBool("isMoving", true);
            }

            if (detected)
            {
                agent.SetDestination(Player.position);
            }

            if (distanceToPlayer <= attackRange)
            {
                animator.SetBool("isAttacking", true);
            }
            else {
                animator.SetBool("isAttacking", false);
            }
        }
    }
}
