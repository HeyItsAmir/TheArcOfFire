using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyLooking : MonoBehaviour
{

    public float detectionRange = 10f;
    public float rotattionSpeed = 5f;

    private GameObject player; 
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector3 directionToPlayer = player.transform.position - transform.position;
            float distanceToPlayer = directionToPlayer.magnitude;

            if (distanceToPlayer <= detectionRange)
            {
                Quaternion TargetRotation = Quaternion.LookRotation(directionToPlayer);
                transform.rotation = Quaternion.Slerp(transform.rotation, TargetRotation, rotattionSpeed * Time.deltaTime);
            }
        }
    }
}
