using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class charMovement : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0) && this.GetComponent<Player>().isWalkable)
        {
            
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            int layerMask = LayerMask.GetMask("Floor");
            if (Physics.Raycast(ray, out hit,1000,layerMask))
            {
                Transform objectHit = hit.transform;
                
                Debug.Log(hit.transform.position);
                this.GetComponent<Animator>().SetBool("Run 0",true);
                navMeshAgent.SetDestination(hit.point);
            }
        }
        if (!navMeshAgent.pathPending)
        {
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                //Debug.Log("Done moving");
                this.GetComponent<Animator>().SetBool("Run 0", false);
            }
        }
        
    }
}
