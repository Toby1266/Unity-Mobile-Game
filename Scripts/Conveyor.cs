using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{    
    public bool rotation; //boolean used to declare if indicators rotate clockwise or anti-clockwise.

    // Update is called once per frame.
    void Update()
    {
        //if rotation = true.
        if (rotation)
        {
            //rotates 90 degrees every second anti-clockwise.
            transform.Rotate(0, 0, 90 * Time.deltaTime);
        }
        //if rotation = false.
        else
        {
            //rotates 90 degrees every second clockwise.
            transform.Rotate(0, 0, -90 * Time.deltaTime);
        }
    }
}
