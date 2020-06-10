/*
Authored by Collin Bradley Nieuw Beerta
Copyright 2020
Scripted updated: 10/06/2020
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class charMovement : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    public GameObject particleTap;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0) && this.GetComponent<Player>().canWalk)
        {
            
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            int layerMask = LayerMask.GetMask("Floor");
            if (Physics.Raycast(ray, out hit,1000,layerMask))
            {
                Transform objectHit = hit.transform;
                
                Debug.Log(hit.transform.position);
                this.GetComponent<Animator>().SetBool("Run 0",true);

                Vector3 spawnTap = new Vector3(hit.point.x, hit.point.y + 0.02f, hit.point.z);
                GameObject particle  = Instantiate(particleTap, spawnTap, particleTap.transform.rotation);
                particle.GetComponent<ParticleSystem>().Emit(2);
                float totalDuration = particle.GetComponent<ParticleSystem>().duration + particle.GetComponent<ParticleSystem>().startLifetime;
                Destroy(particle, totalDuration);
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
