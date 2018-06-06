using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    //code adapted from Zotov, 2017
    public static LevelManager instance = null;
    //Gameobject for current level number
    public GameObject LevelNumber;
    //gameobject for level complete sign
    public GameObject LevelComplete;
    //gameobject for tutorial hint
    public GameObject Tutorial;
    //int for current level number
    public int CurrentLevel;
    //int for level that has been completed
    public int LevelCompleted;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        //declare gameobjects from level number and level complete sign, deactivate level complete sign
        LevelNumber = GameObject.Find("LevelNumber");
        LevelComplete = GameObject.Find("LevelComplete");
        LevelComplete.gameObject.SetActive(false);

        //calculate current level number
        CurrentLevel = SceneManager.GetActiveScene().buildIndex -2;
        LevelCompleted = PlayerPrefs.GetInt("LevelCompleted");
    }


    //run function at end of level
    public void EndLevel()
    {
        //if current level is level 8 
        if (CurrentLevel == 8)
        {
            //after 4 seconds, call LoadMenu function
            Invoke("LoadMenu", 4.0f);
            //activate level completed sign
            LevelComplete.gameObject.SetActive(true);
        }
        else
        {
            if (LevelCompleted < CurrentLevel)
                PlayerPrefs.SetInt("LevelCompleted", CurrentLevel);
            //activate level completed sign
            LevelComplete.gameObject.SetActive(true);
        }
    }
    //end of adapted code


    //load level select menu when this function runs
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }


    //hide tutorial hint when this function run
    public void HideTutorial()
    {
        Tutorial.gameObject.SetActive(false);
    }
}
