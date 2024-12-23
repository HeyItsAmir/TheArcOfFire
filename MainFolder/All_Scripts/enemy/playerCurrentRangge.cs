using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class PlayerCurrentRange : MonoBehaviour
{
    
    public Transform player;
    public float detectionRange = 10f;
    Animator animator;
    private NavMeshAgent agent;
    private bool playerInRange = false;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        //animator.SetBool("EnemyIsMoving" , false);
    }

    private void Update()
    {

        // mohasebe fasele beyn player va enemy
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);


        // agar player dar rang ast
        if (distanceToPlayer <= detectionRange)
        {
            playerInRange = true;
            Debug.Log("Player is in range");

        }
        else
        {
            playerInRange = false;
            //animator.SetBool("PlayerIsClose", false);
            //animator.SetBool("EnemyIsMoving", false);

        }

        // Stop the enemy if the player is in range
        if (playerInRange)
        {
            agent.speed = 0f;
            transform.LookAt(player);
        }
        else
        {
            agent.speed = 3f;
            
        }

    }
}

