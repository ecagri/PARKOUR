using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    float velocityX = 7;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(velocityX, 0, 0);
    }

    // Update is called once per frame
    private void Update()
    {
        rb.velocity = new Vector3(velocityX, 0, 0); 
    }

    private void OnCollisionEnter2D(Collision2D coll){
        
        if(coll.gameObject.name == "ForeGround"){
            velocityX = velocityX * - 1;
            //Debug.Log(rb.velocity.x);
            //float velocityX = rb.velocity.x * -7;
            //rb.velocity = new Vector3(velocityX, 0, 0); 
        }
    }

    private void OnCollisionExit2D(Collision2D coll){
        
    }
}
