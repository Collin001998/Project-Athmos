using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class levelMananger : MonoBehaviour
{
    public int amountLevels;
    public GameObject levelIslandPrefab;
    public Transform startPoint;
    public GameObject eventSystem;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject lastIsland = null;
        for(int i=1; i <= amountLevels; i++)
        {
            if (i == 1)
            {
                lastIsland = Instantiate(levelIslandPrefab, startPoint);
                HubLevelGate levelPlate = lastIsland.transform.Find("Level").transform.Find("plate").GetComponent<HubLevelGate>();
                levelPlate.eventSystem = eventSystem;
                levelPlate.level = i;
            }else
            {
                Vector3 spawnPlace = lastIsland.transform.Find("endIslandLocation").position;
                lastIsland = Instantiate(levelIslandPrefab, spawnPlace,new Quaternion(0f,0f,0f,0f));
                HubLevelGate levelPlate = lastIsland.transform.Find("Level").transform.Find("plate").GetComponent<HubLevelGate>();
                levelPlate.eventSystem = eventSystem;
                levelPlate.level = i;
            }
        }

        NavMeshSurface navMeshSurface = this.GetComponent<NavMeshSurface>();
        navMeshSurface.BuildNavMesh();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
