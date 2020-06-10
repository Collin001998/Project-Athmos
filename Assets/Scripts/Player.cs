/*
Authored by Collin Bradley Nieuw Beerta
Copyright 2020
Scripted updated: 10/06/2020
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerData playerData;
    public int achievedLevel;
    public int totalCurrency;

    private bool hidden;
    private bool isCaught;
    public bool canWalk = true;

    public GameObject eventSystem;


    public bool isHidden => hidden;
    void Start()
    {
        playerData = SaveSystem.LoadSaveFile();
        //Debug.Log("Done level "+ playerData.levels[0].levelNumber + " with amount of points " + playerData.levels[0].scoredPoints);
        achievedLevel = playerData.achievedLevel;
        totalCurrency = playerData.totalCurrency;
        hidden = false;
        isCaught = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isCaught)
        {
            PlayGotCaught();
        }
    }

    private void PlayGotCaught()
    {
        //player loses the level
    }

    public void HidePlayer()
    {
        Debug.Log("Player got hidden.");

        //play sound

        //change shader

        //hide
        this.hidden = true;
    }
    public void UnHidePlayer()
    {
        Debug.Log("Player got unhidden.");

        //play sound

        //change shader

        //unhide
        this.hidden = false;
    }

    public void FinishedLevel()
    {
        eventSystem.GetComponent<Postlevel>().showPostLevelUI = true;
        Portal portal = GameObject.Find("Portal End").GetComponent<Portal>();
        achievedLevel = portal.currentLevel;
        PlayerPrefs.SetInt("result_Level", 0);

        //get savedata
        List<LevelData> levels = this.playerData.levels;
        levels.Add(new LevelData(portal));

        totalCurrency += portal.scoredPoints;

        SaveSystem.SaveGame(this,levels);
    }

    public void FailedLevel()
    {
        eventSystem.GetComponent<Postlevel>().showPostLevelUI = true;
        PlayerPrefs.SetInt("result_Level", 1);
        Debug.Log("level failed");
    }


}
