using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelCanvas : MonoBehaviour {

    //Current level text
    public Text Text;
    //Int to calculate current scene
    public int CurrentLevel;

    private void Start()
    {
        //Assign text component from this object to text variable
        Text = GetComponent<Text>();
        //calculate current level number
        CurrentLevel = SceneManager.GetActiveScene().buildIndex -2;
    }

    private void Update()
    {
        //set text component to say "Level " and current level number
        Text.text = "Level " + CurrentLevel;
    }

}
