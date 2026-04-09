using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class middal : MonoBehaviour
{
    // Start is called before the first frame update
    public logicmanagement logic;
    public bool hasScored = false;
    
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<logicmanagement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "bird_game" && !hasScored)
        {
            logic.aaddscore();
            hasScored = true;
        }
    }
}
