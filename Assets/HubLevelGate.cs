/*
Authored by Collin Bradley Nieuw Beerta
Copyright 2020
Scripted updated: 10/06/2020
*/
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HubLevelGate : MonoBehaviour
{
    public int level;
    public string prefixSceneLevel;
    public GameObject eventSystem;
    public enum State
    {
        Unlocked,
        Locked
    };

    public State state;


    // Start is called before the first frame update
    void Start()
    {
        
        if(level - 1 <= GameObject.Find("Character").GetComponent<Player>().achievedLevel)
        {
            state = State.Unlocked;
        }
        else
        {
            state = State.Locked;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.Unlocked:
                this.GetComponent<Renderer>().materials[1].SetColor("_Color", new Color(255, 255, 255));
                break;
            case State.Locked:
                this.GetComponent<Renderer>().materials[1].SetColor("_Color", new Color(255, 0, 0));
                break;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        PlayerData playerData = GameObject.Find("Character").GetComponent<Player>().playerData;
        if (playerData.levels.Any(X => X.levelNumber == level))
        {
            LevelData levelData = playerData.levels.Where(X => X.levelNumber == level).First();
            eventSystem.GetComponent<LevelDetailUI>().ShowLevelDetails(levelData.levelNumber, levelData.scoredPoints, 0, state);
        }
        else
        {
            eventSystem.GetComponent<LevelDetailUI>().ShowLevelDetails(level, 0, 0, state);
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        eventSystem.GetComponent<LevelDetailUI>().HideLevelDetails();
    }

    
}
