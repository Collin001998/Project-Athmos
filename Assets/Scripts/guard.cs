using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class guard : MonoBehaviour
{
    // Start is called before the first frame update
    NavMeshAgent navMeshAgent;
    void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            Player player = other.gameObject.GetComponent<Player>();
            if (!player.isHidden)
            {
                navMeshAgent.SetDestination(other.gameObject.transform.position);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.GetComponent<Player>())
        {
            Player player = collision.collider.gameObject.GetComponent<Player>();
            player.FailedLevel();
        }
    }
}
