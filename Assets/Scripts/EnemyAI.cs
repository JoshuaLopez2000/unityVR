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
    public float zRotationOffset = 10f; // Desfase en grados en la rotación

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

                Vector3 direction = (Player.position - transform.position).normalized;
                direction.y = 0;

                if (direction != Vector3.zero)
                {
                    Quaternion lookRotation = Quaternion.LookRotation(direction);

                    Quaternion offsetRotation = Quaternion.Euler(lookRotation.eulerAngles.x, lookRotation.eulerAngles.y + zRotationOffset, lookRotation.eulerAngles.z);

                    transform.rotation = Quaternion.Slerp(transform.rotation, offsetRotation, Time.deltaTime * 5f);
                }
            }

            if (distanceToPlayer <= attackRange)
            {
                animator.SetBool("isAttacking", true);
            }
            else
            {
                animator.SetBool("isAttacking", false);
            }
        }
    }
}
