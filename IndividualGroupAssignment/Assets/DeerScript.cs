using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeerScript : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;


    //Patrol
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    void Awake()
    {
        player = GameObject.Find("PlayerObj").transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       //Check sight and range
       playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
       playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

       if(!playerInSightRange && !playerInAttackRange) Patrol();
       if(playerInSightRange && !playerInAttackRange) Chase();
       if(playerInAttackRange && playerInSightRange) Attack();

    }

    void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    void Patrol()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet) agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walk Point reached
        if (distanceToWalkPoint.magnitude < 1f)
        walkPointSet = false;
    }

    private void Chase()
    {
        agent.SetDestination(transform.position);

    }

    private void Attack()
    {
        //make sure enemy dont move
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if(!alreadyAttacked)
        {
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }


    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
