using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemie : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // OnCollisionEnter est appelé quand ce collider/rigidbody commence à toucher un autre rigidbody/collider
    //private void OnCollisionEnter(Collision collision)
    //{
        
    //    if(collision.gameObject.CompareTag("Player"))
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Kill");
            Destroy(transform.parent.gameObject);
        }
    }







}
