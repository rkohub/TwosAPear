using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadControl : MonoBehaviour{

    public LegsControl legScript;
    public GameObject head;
    public MoveCharacter myMovement;
    public bool attached;
    public bool controllingLegs;
    public bool selfEnabled;
    public bool readyToChange;
    private Rigidbody2D body;
    // Start is called before the first frame update

    void Start(){
        attached = true;
        selfEnabled = false;
        readyToChange = false;
        body = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update(){
        myMovement.enabled = !attached && selfEnabled;
        if(attached){
            body.velocity = new Vector2 (0,0);
            this.gameObject.transform.localPosition = new Vector2(0,1.5f);
        }
        if(selfEnabled){
            // Debug.Log("H ENAB");
            if(readyToChange){
                updateControl();
            }
            if (Input.GetKeyDown("j")){
                attached = !attached;
                legScript.attached = attached; 
            }
            if (Input.GetKeyDown("k")){
                readyToChange = true;
            }
        }
    }

    public void updateControl(){
        //Enable Legs Disable Self
        legScript.selfEnabled = true;
        // Debug.Log("H K");
        selfEnabled = false;  
        readyToChange = false; 
    }
}
