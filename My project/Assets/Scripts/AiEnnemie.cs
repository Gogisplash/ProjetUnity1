using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiEnnemie : MonoBehaviour
{

    public GameObject Ennemie;
    //public GameObject Player;
    public InstancePlayer PlayerInstance;
    public GameObject Spawn;
    public GameObject FisrtCheckPoint;
    public GameObject SecondCheckPoint;
    GameObject[] gameObjectArray;
    int CheckPoint = 0;
    //Agent de Navigation
    NavMeshAgent navMeshAgent;

    //Animations
    Animator animator;
    Rigidbody rb;

    public float AttackDistance;
    public float ChaseDistance;

    //Action actuelle
    public string currentAction;
    //string STAND_STATE;
    string WALK_STATE;
    string ATTACK_STATE;
    string Idle;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        WALK_STATE = "isWalking";
        ATTACK_STATE = "isAttacking";
        Idle = "Idle";
        currentAction = Idle;
        gameObjectArray = new GameObject[4];
        gameObjectArray[0] = Spawn;
        gameObjectArray[1] = FisrtCheckPoint;
        gameObjectArray[2] = SecondCheckPoint;
        //gameObjectArray[3] = Player;
        navMeshAgent.SetDestination(FisrtCheckPoint.transform.position);
    }
    void Update()
    {
        if (Ennemie != null)
        {
            ResetAnimation();
            if (Patroning()) 
            {
                return;
            } else
            {
                ResetAnimation();
                navMeshAgent.SetDestination(PlayerInstance.PlayerInstance.transform.position);
                navMeshAgent.speed = 0;
                if (navMeshAgent.remainingDistance < ChaseDistance && navMeshAgent.remainingDistance > AttackDistance)
                {
                    Walk();
                }
                else if (navMeshAgent.remainingDistance <= AttackDistance)
                {
                    Attack();
                }
            }
        }
    }

    bool Patroning()
    {
        float Distance = Vector3.Distance(PlayerInstance.PlayerInstance.transform.position, Ennemie.transform.position);
        if (Distance <= ChaseDistance)
        {
            //CheckPoint = 3;
            Debug.Log("isPlayer");
            return false;
        }
        else
        {
            ChangeDestination();
            Walk();
            if (navMeshAgent.remainingDistance == 0)
            {
                if (CheckPoint == 2)
                {
                    CheckPoint = 0;
                }
                else
                    CheckPoint += 1;
                ChangeDestination();
            }
            return true;
        }
    }

    void ChangeDestination()
    {
        navMeshAgent.SetDestination(gameObjectArray[CheckPoint].transform.position);
    }

    void Walk()
    {
        navMeshAgent.speed = 3;
        //L'action est maintenant "Walk"
        currentAction = WALK_STATE;
        //Le paramètre "Walk" de l'animator = true
        animator.SetBool(currentAction, true);
    }
    void Attack()
    {
        Debug.Log("attack");
        navMeshAgent.speed = 0;
        //L'action est maintenant "Attack"
        currentAction = ATTACK_STATE;
        //Le paramètre "Attack" de l'animator = true
        animator.SetBool(currentAction, true);
    }

    private void ResetAnimation()
    {
        animator.SetBool(WALK_STATE, false);
        animator.SetBool(ATTACK_STATE, false);
    }
}
