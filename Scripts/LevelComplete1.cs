using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelComplete1 : MonoBehaviour {

    //Declared GameObject for Fireworks particle effect    
    public GameObject Fireworks; 
  

    //check if ball as collided with checkpoint inside bin
    private void OnTriggerEnter2D(Collider2D other)
    {
        //If collision is true
        if (other.CompareTag("Hoop2"))
        {
            //Call end level function in level manager
            LevelManager.instance.EndLevel();

            //Disable spriterenderer on ball
            gameObject.GetComponent<Renderer>().enabled = false;
            //Instantiate firework effect, to provide player with feedback of success
            Instantiate(Fireworks, transform.position, Quaternion.identity);

           
            //Wait 3 seconds, then perform function "NextLevel"
            Invoke("NextLevel", 4.0f);
        }
    }

    void NextLevel ()
    {
        //Get current scene number and increment by 1, new number is next scene. load next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
