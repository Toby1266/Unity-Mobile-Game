using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

    //gameobject for player ball prefab
    public GameObject Ball;


    //function to be called when ball respawn buttton is pressed
    public void Spawn()
    {
        //if player has 1 or more lives
        if (LivesManager.Lives > 0)
        {
            //instantiate new player ball and subtract 1 from player lives
            Instantiate(Ball, transform.position, Quaternion.identity);
            LivesManager.Lives -= 1;
        }
    }
}
