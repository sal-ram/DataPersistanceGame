using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public TextMeshProUGUI playerName;
    public TextMeshProUGUI HighscoreName;

    private void Start()
    {
        PersistentData.Instance.LoadingData();

        if (PersistentData.Instance.GetHighscore() == -1)
        {
            HighscoreName.text = "Best score: None. Be first!";
        } 
        else 
        {
            HighscoreName.text = "Best score: " + PersistentData.Instance.GetChampionName() + " : " + PersistentData.Instance.GetHighscore();
        }

        //Debug.Log(Application.persistentDataPath);
    }

    public void StartGame()
    {
        PersistentData.Instance.NameIsChosen(playerName.text);
        SceneManager.LoadScene(1);
    }

    void ExitGame()
    {
        
    }


}
