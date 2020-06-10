/*
Authored by Collin Bradley Nieuw Beerta
Copyright 2020
Scripted updated: 10/06/2020
*/
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static void SaveGame(Player player, List<LevelData> levelData)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/SaveFile.atmos";
        FileStream fileStream = new FileStream(path, FileMode.Create);

        PlayerData playerData = new PlayerData(player, levelData);

        formatter.Serialize(fileStream, playerData);
        fileStream.Close();
    }

    public static PlayerData LoadSaveFile()
    {
        
        string path = Application.persistentDataPath + "/SaveFile.atmos";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);
            PlayerData playerData = formatter.Deserialize(fileStream) as PlayerData;
            fileStream.Close();
            return playerData;
        }
        else
        {
            //set default save
            Player player = new Player();
            player.totalCurrency = 0;
            player.achievedLevel = 0;

            List<LevelData> levels = new List<LevelData>();

            SaveGame(player, levels);

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);
            PlayerData playerData = formatter.Deserialize(fileStream) as PlayerData;
            fileStream.Close();
            Debug.LogError("PlayerData not found and made new savefile.");
            return playerData;
        }
        
    }
}
