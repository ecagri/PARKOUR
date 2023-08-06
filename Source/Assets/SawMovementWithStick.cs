using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawMovementWithStick : MonoBehaviour
{

    private Rigidbody2D rb;
    float velocityY = -3;
    bool down = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(0, velocityY, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(down && rb.transform.position.y < -6){
            velocityY = velocityY * -1;
            down = false;
        }else if(!down && rb.transform.position.y > -3){
            velocityY = velocityY * -1;
            down = true;
        }
        
        rb.velocity = new Vector3(0, velocityY, 0);
    }
}
