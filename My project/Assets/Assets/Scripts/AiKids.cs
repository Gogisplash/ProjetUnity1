using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class AiKids : MonoBehaviour
{
    NavMeshAgent kid;
    Animator mAnimator;
    bool isWalking;
    public Vector3 returnPoint;
    // Start is called before the first frame update
    void Start()
    {
        kid = GetComponent<NavMeshAgent>();
        mAnimator = GetComponent<Animator>();
        isWalking = mAnimator.GetBool("isWalking");
    }

    // Update is called once per frame
    void Update()
    {
       if( kid.remainingDistance < 1)
        {
            mAnimator.SetBool("isWalking", false);
        }
    
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            kid.SetDestination(returnPoint);
            mAnimator.SetBool("isWalking", true); 
        }
    }
    
}
