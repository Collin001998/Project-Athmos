/*
Authored by Collin Bradley Nieuw Beerta
Copyright 2020
Scripted updated: 10/06/2020
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int achievedLevel;
    public int totalCurrency;
    public List<LevelData> levels;
    //public HubData hubData;
    //public SettingsData settingsData;

    public PlayerData(Player player, List<LevelData> levelData)
    {
        achievedLevel = player.achievedLevel;
        totalCurrency = player.totalCurrency;
        levels = levelData;
    }
}
