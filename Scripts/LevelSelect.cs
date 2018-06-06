using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour {

    //integer for completed level
    public int LevelCompleted;
    //buttons for corresponding levels
    public Button Level2, Level3, Level4, Level5, Level6, Level7, Level8;

    //Code adapted from Zotov, 2017
	void Start () {
       
        //begin scene, set current level completed and set buttons 2 through 8 to uninteractable
        LevelCompleted = PlayerPrefs.GetInt("LevelCompleted");
        Level2.interactable = false;
        Level3.interactable = false;
        Level4.interactable = false;
        Level5.interactable = false;
        Level6.interactable = false;
        Level7.interactable = false;
        Level8.interactable = false;

       
        switch (LevelCompleted) {
            //when case 1 switches set level 2 button to interactable
            case 1:
                Level2.interactable = true;
                break;
            //when case 2 switches set level 2 and 3 button to interactable
            //contiune in this fashion for all remaining cases
            case 2:
                Level2.interactable = true;
                Level3.interactable = true;
                break;
            case 3:
                Level2.interactable = true;
                Level3.interactable = true;
                Level4.interactable = true;
                break;
            case 4:
                Level2.interactable = true;
                Level3.interactable = true;
                Level4.interactable = true;
                Level5.interactable = true;
                break;
            case 5:
                Level2.interactable = true;
                Level3.interactable = true;
                Level4.interactable = true;
                Level5.interactable = true;
                Level6.interactable = true;
                break;
            case 6:
                Level2.interactable = true;
                Level3.interactable = true;
                Level4.interactable = true;
                Level5.interactable = true;
                Level6.interactable = true;
                Level7.interactable = true;
                break;
            case 7:
                Level2.interactable = true;
                Level3.interactable = true;
                Level4.interactable = true;
                Level5.interactable = true;
                Level6.interactable = true;
                Level7.interactable = true;
                Level8.interactable = true;
                break;
        }
	}
	
    //call this function when a level button is pressed 
	public void LoadLevel(int Level)
    {
        //if player has more than 0 lives
        if (LivesManager.Lives > 0)
        {
            //reduce lives by 1 and load level relative to level button pressed
            LivesManager.Lives -= 1;
            SceneManager.LoadScene(Level);
        }
    }

    //call this function when go back button is pressed
    public void LoadMenu()
    {
        //load main menu scene
        SceneManager.LoadScene("MainMenu");
    }

    //if reset progression button is pressed, set all level buttons (except level 1) to inactive, and delete existing player prefs
    public void ResetPrefs()
    {
        Level2.interactable = false;
        Level3.interactable = false;
        Level4.interactable = false;
        Level5.interactable = false;
        Level6.interactable = false;
        Level7.interactable = false;
        Level8.interactable = false;
        PlayerPrefs.DeleteAll();
    }

    //end of adapted code
}
