using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PersistentData : MonoBehaviour
{
    public static PersistentData Instance;

    private string playerNameSaved;

    private int Highscore = -1;

    private string ChampionName;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

    }

    public void NameIsChosen(string playerName)
    {
        playerNameSaved = playerName;
    }

    public void ChampionIsChosen(string champName)
    {
        ChampionName = champName;
    }

    public void HighscoreUpgrade(int highscore)
    {
        Highscore = highscore;
    }

    public string GetChosenName()
    {
        return playerNameSaved;
    }

    public string GetChampionName()
    {
        return ChampionName;
    }

    public int GetHighscore()
    {
        return Highscore;
    }

    [Serializable]
    class SaveData
    {
        public string playerName;

        public int Highscore;

        public string ChampionName;
    }

    public void SavingData()
    {
        SaveData data = new SaveData();
        data.playerName = playerNameSaved;
        data.Highscore = Highscore;
        data.ChampionName = ChampionName;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadingData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerNameSaved = data.playerName;
            Highscore = data.Highscore;
            ChampionName = data.ChampionName;
        }
    }
}
