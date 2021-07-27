using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour{
    // Start is called before the first frame update

    //Todo
    //Max Speed
    //X Ammount of Jumps

    public float jumpMagnitude;
    private Rigidbody2D body;
    private float xSpeedCap;
    public float accelerationMagnitude;

    void Start(){
        body = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetKey("a")){
            body.AddForce(Vector2.left * accelerationMagnitude);
        }
        if (Input.GetKey("d")){
            body.AddForce(Vector2.right * accelerationMagnitude);
        }
        if (Input.GetKeyDown("space")){
            jump();
        }
    }

    public void jump(){
       body.AddForce(Vector2.up * jumpMagnitude);
    }
}
