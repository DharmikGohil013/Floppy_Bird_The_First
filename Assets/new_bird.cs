using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class new_bird : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D myrigidbody;
    public float flapstrnth;
    public logicmanagement logic;
    public bool birdalive = true;
    void Start()
    {
        gameObject.name = "bird_game";
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<logicmanagement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && birdalive)
        {
            myrigidbody.linearVelocity = Vector2.up * flapstrnth;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameover();
        birdalive = false;
    }
}
