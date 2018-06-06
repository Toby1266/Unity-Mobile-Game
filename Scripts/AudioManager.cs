using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    private void Start()
    {
        //Add Music gameobject to music gameobject array
        GameObject[] MusicSource = GameObject.FindGameObjectsWithTag("Music");
        
        //If music gameobject already exists, destroy new music gameobject (so only 1 is in scene)
        if (MusicSource.Length > 1)
        {
            Destroy(this.gameObject);
        }

        //Do not destroy existing music gameobject when new scene loads, this ensures that music plays in a continous loop throughout app
        DontDestroyOnLoad(this.gameObject);
    }
}
