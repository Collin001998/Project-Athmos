/*
Authored by Collin Bradley Nieuw Beerta
Copyright 2020
Scripted updated: 10/06/2020
*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class levelMananger : MonoBehaviour
{
    public int amountLevels;
    public List<GameObject> levelIslandPrefabs;
    public GameObject comingSoon;
    public Transform startPoint;
    public GameObject eventSystem;
    
    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Random.InitState(CharSeed("Flexing"));
        GameObject lastIsland = null;
        for(int i=1; i <= amountLevels;)
        {
            if (i == 1)
            {
                lastIsland = Instantiate(GetRandomIsland(), startPoint.position,new Quaternion(0f,0f,0f,0f));

                foreach(Transform child in lastIsland.transform)
                {
                    if (child.CompareTag("Plate"))
                    {
                         HubLevelGate levelPlate = child.Find("plate").GetComponent<HubLevelGate>();
                         levelPlate.eventSystem = eventSystem;

                         if(i > amountLevels)
                         {
                             Destroy(child.gameObject);
                         }
                         else
                         {
                             levelPlate.level = i;
                         }
                        i++;
                        Debug.Log(i);
                    }
                }


                //HubLevelGate levelPlate = lastIsland.transform.Find("Level").transform.Find("plate").GetComponent<HubLevelGate>();
                //levelPlate.eventSystem = eventSystem;
                //levelPlate.level = i;
            }else
            {
                Vector3 spawnPlace = lastIsland.transform.Find("endIslandLocation").position;
                lastIsland = Instantiate(GetRandomIsland(), spawnPlace,new Quaternion(0f,0f,0f,0f));

                foreach (Transform child in lastIsland.transform)
                {
                    if (child.CompareTag("Plate"))
                    {
                        HubLevelGate levelPlate = child.Find("plate").GetComponent<HubLevelGate>();
                        levelPlate.eventSystem = eventSystem;

                        if (i > amountLevels)
                        {
                            Destroy(child.gameObject);
                            
                        }
                        else
                        {
                            levelPlate.level = i;
                        }
                        i++;
                        Debug.Log(i);
                    }
                }

                //HubLevelGate levelPlate = lastIsland.transform.Find("Level").transform.Find("plate").GetComponent<HubLevelGate>();
                //levelPlate.eventSystem = eventSystem;
                //levelPlate.level = i;
                
            }
            
        }
        NavMeshSurface navMeshSurface = this.GetComponent<NavMeshSurface>();
        navMeshSurface.BuildNavMesh();
        Instantiate(comingSoon, lastIsland.transform.Find("endIslandLocation").position, new Quaternion(0f, 0f, 0f, 0f));

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    GameObject GetRandomIsland()
    {
        GameObject island = levelIslandPrefabs[0];

        
        int random = UnityEngine.Random.Range(0,levelIslandPrefabs.Count -1);
        island = levelIslandPrefabs[random];
        return island;
    }

    public int CharSeed(string s)
    {
        int final = 0;
        foreach (char c in s)
        {
            final += char.ToUpper(c) - 64;

        }
        return final;
    }
}
