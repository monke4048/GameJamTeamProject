using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGravity : MonoBehaviour
{
    public Rigidbody2D rb;
    public Movement m;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(m.pos == Vector2.zero)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
        }
        if(m.pos != Vector2.zero){
            rb.constraints = RigidbodyConstraints2D.None;
        }
    }
}
