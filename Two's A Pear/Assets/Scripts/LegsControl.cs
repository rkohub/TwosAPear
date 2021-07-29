using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegsControl : MonoBehaviour{

    public HeadControl headScript;
    public GameObject head;
    public MoveCharacter myMovement;
    public bool attached;
    public bool controllingLegs;
    public bool selfEnabled;
    public bool readyToChange;
    // Start is called before the first frame update

    void Start(){
        attached = true;
        selfEnabled = true;
        readyToChange = false;
    }

    // Update is called once per frame
    void Update(){
        myMovement.enabled = selfEnabled || attached;
        if(selfEnabled || attached){
            // Debug.Log("L ENAB");
            if(readyToChange){
                updateControl();
            }
            if (Input.GetKeyDown("j")){
                attached = !attached;
                headScript.attached = attached; 
            }
            if (Input.GetKeyDown("k")){
                readyToChange = true;
            }
        }
    }

    public void updateControl(){
        //Enable Legs Disable Self
        headScript.selfEnabled = true;  
        // Debug.Log("L K"); 
        selfEnabled = false;   
        readyToChange = false;
    }
}
