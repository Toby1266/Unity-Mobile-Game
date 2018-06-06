using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class TouchManager : MonoBehaviour {

    //gameobject for interactable objects
    public GameObject Interactable;
    //gameobject for player ball
    public GameObject Ball;
    //gameobject for respawn chute
    public GameObject Respawn;
    //vector for touch position
    private Vector3 ScreenTouchPosition;
    //ray for screen touch raycast
    private Ray TouchRay;


    //code adapted from Unity Technologies, 2018
    private void Start()
    {
        //on start, if scene number is divisble by 5, run show ad function
        if (SceneManager.GetActiveScene().buildIndex % 5 == 0)
        {
            ShowAd();
        }        
    }

    //display ad
    public void ShowAd()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
    }
    //end of adapted code

    void Update()
    {
        //if user touches screen once
        if (Input.touchCount == 1)
        {
            //begin touch phases
            switch (Input.GetTouch(0).phase)
            {
                //when player touches screen, call raycast functions. While player holds on screen, call MoveInteractable function. When player ends touching screen, call EndTouch function.
                case TouchPhase.Began:
                    Raycast();
                    break;
                case TouchPhase.Moved:
                    MoveInteractable();
                    break;
                case TouchPhase.Ended:
                    EndTouch();
                    break;
            }
        }
    }

    //Raycast function
    void Raycast()
    {
        //perform 2D raycast from screen touched position
        TouchRay = Camera.main.ScreenPointToRay(Input.touches[0].position);
        RaycastHit2D hit = Physics2D.Raycast(TouchRay.origin, TouchRay.direction);

        //if raycast htis an object
        if(hit)
        {
            //if hit object has tag "interactable"
            if(hit.collider.CompareTag("Interactable"))
            {
                //set hit object to interactable gameobject
                Interactable = hit.transform.gameObject;
            }
            //if hit object has tag "bomb
            if(hit.collider.CompareTag("Bomb"))
            {
                //enable explosion script on bomb
                GameObject.FindWithTag("Bomb").GetComponent<Explode>().enabled = true;
            }
            //if hit object has tag "Respawn"
            if(hit.collider.CompareTag("Respawn"))
            {
                //find and destroy current ball in scene.
                Ball = GameObject.FindGameObjectWithTag("Ball");
                Destroy(Ball);
                //Call function "Spawn" on respawn gameobject
                GameObject.FindWithTag("Respawn").GetComponent<Respawn>().Spawn();
            }

        }
    }

    //MoveInteractble function
    void MoveInteractable()
    {
        //if interactable is a conveyor belt, disable its box collider, this prevents player from carrying ball across screen on conveyor.
        if(Interactable.name == "Conveyor_Left_Interactable" || Interactable.name == "Conveyor_Right_Interactable")
        {
            Interactable.GetComponent<BoxCollider2D>().enabled = false;
        }

        //calculate screen touch position
        ScreenTouchPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 1));

        //if object is called "SliderVert" only allow it to move across X axis of screen touch position
        if (Interactable.name == "SliderVert")
        {
            ScreenTouchPosition.x = Interactable.transform.position.x;
        }

        //if object is called "SliderHor" only allow it ot move across Y axis of screen touch position
        if (Interactable.name == "SliderHor")
        {
            ScreenTouchPosition.y = Interactable.transform.position.y;
        }

        //if there is no interactable object, set interactable to screen touch position
        if (Interactable != null)
        {
            Interactable.transform.position = ScreenTouchPosition;
        }        
    }

    //EndTouch function
    void EndTouch()
    {
        //at end of touch, if interactable object was a conveyor, reactivate their box collider
        if (Interactable.name == "Conveyor_Left_Interactable" || Interactable.name == "Conveyor_Right_Interactable")
        {
            Interactable.GetComponent<BoxCollider2D>().enabled = true;
        }

        if (Interactable != null)
        {            
            Interactable.transform.position = new Vector3(Interactable.transform.position.x, Interactable.transform.position.y, 0);

            Interactable = null;
        }
    }




}
