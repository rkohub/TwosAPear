using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour{
    // Start is called before the first frame update

    //Todo
    //Fix Error where reset jumps on hit bottom of platforms

    public float jumpMagnitude;
    private Rigidbody2D body;
    private float accelerationMagnitude;
    public bool coll;
    public int maxJumps;
    private int jumpsUsed;
    private float maxVelocity;
    private Vector2 force;

    void Start(){
        body = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update(){
        if(coll){
            accelerationMagnitude = 1.5f;
            maxVelocity = 3;
        }else{
            accelerationMagnitude = 1;
            maxVelocity = 2;
        }
        if(Mathf.Abs(body.velocity[0]) > maxVelocity){
            body.velocity = new Vector2 (Mathf.Sign(body.velocity[0]) * maxVelocity,body.velocity[1]);
        }
        
        if (Input.GetKey("a")){
            body.AddForce(Vector2.left * accelerationMagnitude);
        }
        if (Input.GetKey("d")){
            body.AddForce(Vector2.right * accelerationMagnitude);
        }
        if (Input.GetKeyDown("space") && jumpsUsed < maxJumps){
            jump();
        }

         // print(body.velocity);
    }

    public void jump(){
       body.velocity = new Vector2 (body.velocity[0],0);
       body.AddForce(Vector2.up * jumpMagnitude);
       jumpsUsed += 1;
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Stage"){
            coll = true;
            jumpsUsed = 0;
        }
        
    }

    void OnCollisionExit2D(Collision2D collision){
        if(collision.gameObject.tag == "Stage"){
            coll = false;
        }
    }
}
