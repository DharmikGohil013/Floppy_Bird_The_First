using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class new_bird : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D myrigidbody;
    public float flapstrnth = 25f;
    public logicmanagement logic;
    public bool birdalive = true;
    public int maxJumps = 2;
    private int jumpsRemaining;
    public float gravityScale = 2f;
    
    void Start()
    {
        gameObject.name = "bird_game";
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<logicmanagement>();
        jumpsRemaining = maxJumps;
        myrigidbody.gravityScale = gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && birdalive && jumpsRemaining > 0)
        {
            myrigidbody.linearVelocity = Vector2.up * flapstrnth;
            jumpsRemaining--;
        }
        
        // Reset jumps when bird is moving upward
        if(myrigidbody.linearVelocity.y > 0 && jumpsRemaining == maxJumps - 1)
        {
            jumpsRemaining = maxJumps;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameover();
        birdalive = false;
    }
}
