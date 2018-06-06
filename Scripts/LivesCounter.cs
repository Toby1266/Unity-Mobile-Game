using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesCounter : MonoBehaviour {

    //delcared text variable for displaying player's lives
    public Text Text;
    //int for players current lives
    public int CurrentLives;

    public void Start()
    {
        //assign text component to text variable
        Text = GetComponent<Text>();
    }

    public void Update()
    {
        //calculate current lives
        CurrentLives = LivesManager.Lives;

        //set text component to "Lives " + current lives + " /5"
        Text.text = "Lives: " + CurrentLives + "/5";
    }
}
