using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour {

    //Gameobject for explosion containing point effector
    public GameObject Explosion;
    //sprite for explosion 
    public Sprite SprExplosion;
    //SpriteRenderer for bomb
    public SpriteRenderer SpriteRenderer;
    //Rigidbody from bomb
    public Rigidbody2D Rbody;

	
	void Start () {

        //whenn explosion starts, change spriterender from bomb to the explosion sprite
        SpriteRenderer.sprite = SprExplosion;
        //start end of explosion coroutine
        StartCoroutine(EndExplosion());

        //disable rigidybody on bomb, to make explosion sprite remain motionless (instead of moving through scene)
        GetComponent<Rigidbody2D>().Sleep();
        Rbody.isKinematic = true;
    }

    //end explosion coroutine
	IEnumerator EndExplosion()
    {
        //Instantiante explosion gameobject with point effector, wait 0.1 seconds then destroy explosion gameobject
        GameObject Exploded = Instantiate(Explosion, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.1f);        
        Destroy(Exploded);
        //wait 2 seconds, destroy this gameobject 
        yield return new WaitForSeconds(2.0f);
        Destroy(gameObject);
        
    }
}
