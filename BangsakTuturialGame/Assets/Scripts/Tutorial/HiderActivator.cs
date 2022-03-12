using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class HiderActivator : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask IsGround, IsPlayer;
    public float health;
    public GameObject projectile;
    //Patrol
    public Vector3 WalkPoint;
    bool WalkPointSet;
    public float WalkPointRange;
    //Attacking
    public float TimeBetweenAttacks;
    bool AlreadyAttacked;    
    //States
    public float SightRange, AttackRange;
    public bool PlayerInSightRange, PlayerInAttackRange;
    private void Awake()
    {
        player = GameObject.Find("Character").transform;
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        PlayerInSightRange = Physics.CheckSphere(transform.position, SightRange, IsPlayer);
        PlayerInAttackRange = Physics.CheckSphere(transform.position, AttackRange, IsPlayer);

        if(!PlayerInSightRange && !PlayerInAttackRange){
            Patrolling();
        }
        if(PlayerInSightRange && !PlayerInAttackRange){
            ChasePlayer();
        }
        if(PlayerInAttackRange && PlayerInAttackRange){
            AttackPlayer();
        }
    }
    private void Patrolling(){
        SearchWalkPoint();
        if(!WalkPointSet){
            SearchWalkPoint();
        }
        if(WalkPointSet){
            agent.SetDestination(WalkPoint);
        }
        Vector3 DistanceToWalkPoint = transform.position - WalkPoint;
        if(DistanceToWalkPoint.magnitude < 1f){
            WalkPointSet = false;
        }
    }
    private void SearchWalkPoint(){
        float randomZ = Random.Range(-WalkPointRange, WalkPointRange);
        float randomX = Random.Range(-WalkPointRange, WalkPointRange);
        WalkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        if(Physics.Raycast(WalkPoint, -transform.up, 2f, IsGround)){

        }
    }
    private void ChasePlayer(){
        agent.SetDestination(player.position);
    }
    private void AttackPlayer(){
        agent.SetDestination(player.position);
        transform.LookAt(player);
        // if(!AlreadyAttacked){
        //     Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
        //     rb.AddForce(transform.up * 8f, ForceMode.Impulse);
        //     AlreadyAttacked = true;
        //     Invoke(nameof(ResetAttack), TimeBetweenAttacks);
        // }
    }
    private void ResetAttack(){
        AlreadyAttacked = false;
    }

    private void DestroyEnemy(){
        Destroy(gameObject);
    }

}
