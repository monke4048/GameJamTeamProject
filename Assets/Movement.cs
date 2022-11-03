using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float JumpHeight;
    public float RayDistance;
    public LayerMask JumpLayer;
    public bool CanJump;
    public Animator anim;
    //variables below this should not be changed
    Vector3 velocity = Vector3.zero;
    float t = .05f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Physics2D.Raycast(transform.position,Vector2.down,RayDistance,JumpLayer))
        {
            CanJump = true;
        }
        else
        {
            CanJump = false;
        }
        if(Input.GetKey(KeyCode.Space) && CanJump != false)
        {
            anim.SetBool("Canjump",true);
            rb.AddForce(Vector2.up * JumpHeight * Time.fixedDeltaTime);
        }
        else{
            anim.SetBool("Canjump",false);
        }
        if(CanJump == false){
        float x = Input.GetAxis("Horizontal") * 0.5f;
        anim.SetFloat("Speed",Mathf.Abs(x));
        Vector2 pos = new Vector2(x*speed* Time.fixedDeltaTime,rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity,pos,ref velocity,t);
        Vector2 flip = transform.localScale;
        if(x > 0){
            flip.x = 2;
        }
        if(x < 0){
            flip.x = -2;
        }
        transform.localScale = flip;
        }
        if(CanJump == true){
        float x = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed",Mathf.Abs(x));
        Vector2 pos = new Vector2(x*speed* Time.fixedDeltaTime,rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity,pos,ref velocity,t);
        Vector2 flip = transform.localScale;
        if(x > 0){
            flip.x = 2;
        }
        if(x < 0){
            flip.x = -2;
        }
        transform.localScale = flip;
        }

    }
}
