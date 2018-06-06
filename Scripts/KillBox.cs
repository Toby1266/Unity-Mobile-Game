using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBox : MonoBehaviour {

    //Check if bomb or ball are colliding with kill box outside of camera view. If Yes, destroy them.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bomb" || collision.gameObject.tag == "Ball")
        {
            Destroy(collision.gameObject);
        }
    }
}
