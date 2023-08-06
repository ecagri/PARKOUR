using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    bool isGrounded = false;
    private BoxCollider2D coll;
    bool isFinished = false;
    private Rigidbody2D rb;
    private Animator animator;
    private float previousY;
    [SerializeField] private LayerMask JumpableGround;
    //private GameObject gameObject;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //gameObject = GameObject.FindGameObjectWithTag("Player");
        rb.velocity= new Vector3(0, 0, 0);
        coll = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        previousY = rb.transform.position.y;
    }

    // Update is called once per frame
    private void Update()
    {   
        isGrounded = isGround();
        
        if(rb.transform.position.y < previousY){
            animator.SetBool("jumping", false);
            animator.SetBool("falling", true);
        }
        if(isGrounded){
            animator.SetBool("falling", false);
        }
        if(rb.transform.position.y < -15){
            animator.SetBool("dying", true);
            rb.bodyType = RigidbodyType2D.Static;
        }
        float dirX = Input.GetAxisRaw("Horizontal");
        
        rb.velocity = new Vector3(dirX * 10f, rb.velocity.y, 0);
        rb.transform.rotation = Quaternion.Euler(0, 0, 0);
        if(Input.GetButton("Jump") && isGrounded){
            rb.velocity = new Vector3(rb.velocity.x, 15, 0);
            animator.SetBool("jumping", true);

        }
        
        if(dirX > 0f || dirX < 0f){
            animator.SetBool("running", true);
        }else{
            animator.SetBool("running", false);
        }

        previousY = rb.transform.position.y;
    }
    
    private void OnCollisionEnter2D(Collision2D coll){
        
        if(coll.gameObject.name == "ForeGround"){
            isGrounded = true;
        }else if(coll.gameObject.name == "Traps" || coll.gameObject.name == "Trap3" ||coll.gameObject.name == "Saw"){  
            animator.SetBool("dying", true);
            rb.bodyType = RigidbodyType2D.Static;
        }else if(coll.gameObject.name == "Checkpoint"){
            animator.SetBool("dying", true);
            rb.bodyType = RigidbodyType2D.Static;
            isFinished = true;
        }
    }

    private void Respawn(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void OnCollisionExit2D(Collision2D coll){
        if(coll.gameObject.name == "ForeGround"){
            isGrounded = false;
        }
    }

    private void load(){
        if(isFinished)
            SceneManager.LoadScene("New Game");
        else
            SceneManager.LoadScene("Game Over");


    }

    private bool isGround(){
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, JumpableGround);
    }
}
