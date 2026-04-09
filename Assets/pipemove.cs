using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipemove : MonoBehaviour
{
    // Start is called before the first frame update
    public float movespeed = 10;
    public float deadzone = -45;
    public float acceleration = 0.4f;
    private float currentSpeed;
    
    // Vertical movement variables
    private logicmanagement logic;
    private bool verticalMovementEnabled = false;
    public float verticalSpeed = 2f;
    public float verticalRange = 3f;
    public int scoreThresholdForVertical = 500;
    private float verticalDirection = 1f;
    private float startY;
    
    void Start()
    {
        currentSpeed = movespeed;
        startY = transform.position.y;
        
        // Find logic manager to check score
        GameObject logicObj = GameObject.FindGameObjectWithTag("logic");
        if(logicObj != null)
        {
            logic = logicObj.GetComponent<logicmanagement>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if score is 500 or more for vertical movement
        if(logic != null && logic.playerscore >= scoreThresholdForVertical)
        {
            verticalMovementEnabled = true;
        }
        
        currentSpeed += acceleration * Time.deltaTime;
        transform.position = transform.position + (Vector3.left * currentSpeed) * Time.deltaTime;
        
        // Add vertical movement if enabled
        if(verticalMovementEnabled)
        {
            float newY = transform.position.y + (verticalDirection * verticalSpeed * Time.deltaTime);
            
            // Reverse direction if we reach limits
            if(newY > startY + verticalRange)
            {
                verticalDirection = -1f;
            }
            else if(newY < startY - verticalRange)
            {
                verticalDirection = 1f;
            }
            
            transform.position = new Vector3(transform.position.x, 
                                            transform.position.y + (verticalDirection * verticalSpeed * Time.deltaTime), 
                                            transform.position.z);
        }
        if (transform.position.x < deadzone)
        {
            Debug.Log("pipe delited");
            Destroy(gameObject);
        }
    }
}
