using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour {

    //Public gameobject for bomb to be declared in inspector
    public GameObject Bomb;

    void Start () {

        //Start bomb spawn coroutine
        StartCoroutine(SpawnBombs());
	}
	

    //Bomb coroutine
	IEnumerator SpawnBombs()
    {
        //continous while loop
        while (true)
        {
            //instantiate bomb gameobject then wait 4 seconds before repeating loop
            Instantiate(Bomb, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(4f);
        }
    }
}
