/*
Authored by Collin Bradley Nieuw Beerta
Copyright 2020
Scripted updated: 10/06/2020
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelData
{
    public int levelNumber;
    public int scoredPoints;

    public LevelData(Portal portal)
    {
        levelNumber = portal.currentLevel;
        scoredPoints = portal.scoredPoints;
    }
}
