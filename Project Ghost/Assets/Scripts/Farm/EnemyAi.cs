using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    [Header("Enemy Level 1 Stats")]
    public byte viewRadius1 = 10;
    public byte viewAngle1 = 30;
    public byte hearRange1 = 1;
    public byte chaseSpeed1 = 3;

    [Header("Enemy Level 2 Stats")]
    public byte viewRadius2 = 10;
    public byte viewAngle2 = 30;
    public byte hearRange2 = 1;
    public byte chaseSpeed2 = 3;

    [Header("Enemy Level 3 Stats")]
    public byte viewRadius3 = 10;
    public byte viewAngle3 = 30;
    public byte hearRange3 = 1;
    public byte chaseSpeed3 = 3;

    [Header("Values")]
    public byte EnemyLevel = 1;
    public bool win = false;

    float viewRadius;
    float viewAngle;

    public float patrolSpeed;
    float chaseSpeed;

    public float health;

    public bool inVision;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    bool alreadyAttacked;

    //States
    public float hearRange, attackRange;
    public bool playerInHearRange, playerInAttackRange;
    [Header("References")]
    

    public NavMeshAgent agent;
    public Transform player;
    public GameManager gameManager;
    public Animator anim;

    public LayerMask whatIsGround, whatIsPlayer, whatsIsObstacle;

    private void Awake()
    {
        EnemyLevel = 1;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if(gameManager.noOfCursedChicken < 3)
        {
            EnemyLevel = 1;
        }else if(gameManager.noOfCursedChicken >=3 && gameManager.noOfCursedChicken < 6)
        {
            EnemyLevel = 2;
        }else if(gameManager.noOfCursedChicken >= 6)
        {
            EnemyLevel = 3;
        }
        playerInHearRange = Physics.CheckSphere(transform.position, hearRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        Vector3 playerTarget = (player.transform.position - transform.position).normalized;

        if(Vector3.Angle(transform.forward, playerTarget) < viewAngle / 2)
        {
            // Debug.Log("In Angle");
            float distanceToTarget = Vector3.Distance(transform.position, player.transform.position);
            if(distanceToTarget < viewRadius)
            {
                // Debug.Log("In Vision");
                if (Physics.Raycast(transform.position, playerTarget, distanceToTarget, whatIsPlayer) == true )
                {
                    // Debug.Log("You are a Player");
                    ChasePlayer();
                    inVision = true;
                }
                else
                {
                    // Debug.Log("Else You are Player");
                    inVision = false;
                    // Debug.Log("I see Obstacle");
                }
            }
            else
            {
                // Debug.Log("Else In Vision");
                inVision = false;
                Patroling();
            }
        }
        else
        {
            // Debug.Log("Not In Angle");
            inVision = false;
            if ((!playerInHearRange && !playerInAttackRange) || !inVision) Patroling();
        }
        // Debug.Log("Else");
        //Check for sight and attack range
        

        // if ((!playerInHearRange && !playerInAttackRange) || !inVision) Patroling();
        if ((playerInHearRange && !playerInAttackRange) || inVision) ChasePlayer();
        if (playerInAttackRange && playerInHearRange && inVision) AttackPlayer();

        if(gameManager.noOfCursedChicken == 9)
        {
            DestroyEnemy();
        }
        
    }

    private void FixedUpdate()
    {
        if(EnemyLevel == 1)
        {
            viewRadius = viewRadius1;
            viewAngle = viewAngle1;
            hearRange = hearRange1;
            chaseSpeed = chaseSpeed1;
        }
        else if (EnemyLevel == 2)
        {
            viewRadius = viewRadius2;
            viewAngle = viewAngle2;
            hearRange = hearRange2;
            chaseSpeed = chaseSpeed2;
        } 
        else if (EnemyLevel == 3)
        {
            viewRadius = viewRadius3;
            viewAngle = viewAngle3;
            hearRange = hearRange3;
            chaseSpeed = chaseSpeed3;
        }
    }
    private void Patroling()
    {
        // Debug.Log("Paterol");
        agent.speed = patrolSpeed;
        anim.SetBool("Chase", false);
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.speed = chaseSpeed;
        anim.SetBool("Chase", true);
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        gameManager.EndGame(); 
        
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }
    private void DestroyEnemy()
    {
        win = true;
        gameManager.EndGame();
        Debug.Log("We WOn");
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, hearRange);
    }
}
