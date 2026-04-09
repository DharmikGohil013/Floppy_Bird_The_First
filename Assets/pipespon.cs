using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipespon : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pipe;
    public float spawtime = 1.3f;
    public float time = 0;
    public float heightofset = 10;
    
    // AI and randomness variables
    private float minSpawnTime = 1.0f;
    private float maxSpawnTime = 1.6f;
    private float currentSpawnTime;
    private int spawnPattern = 0;
    private float lastHeight = 0;
    private int consecutiveSameHeight = 0;
    
    //void showpipe();
    void Start()
    {
        showpipe();
        time = spawtime * 0.5f; // Start halfway to next spawn
        currentSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        lastHeight = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(time < currentSpawnTime)
        {
            time += Time.deltaTime;
        }
        else
        {
            showpipe();   
            time = 0;
            // AI: Randomly change spawn time for unpredictability
            currentSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
            
            // AI: Change pattern every 3-5 pipes
            if(Random.Range(0, 100) < 20)
            {
                spawnPattern = Random.Range(0, 4);
            }
        }
    }
    void showpipe()
    {
        float lowestpoint = transform.position.y - heightofset;
        float hightpoint = transform.position.y + heightofset;
        float targetHeight = 0;
        
        // AI Pattern Selection
        switch(spawnPattern)
        {
            case 0: // Random chaos
                targetHeight = Random.Range(lowestpoint, hightpoint);
                break;
                
            case 1: // Wave pattern (sinusoidal)
                targetHeight = transform.position.y + Mathf.Sin(Time.time * 2) * heightofset;
                break;
                
            case 2: // Zigzag pattern
                if(consecutiveSameHeight > 1)
                {
                    targetHeight = (lastHeight > transform.position.y) ? lowestpoint : hightpoint;
                    consecutiveSameHeight = 0;
                }
                else
                {
                    targetHeight = lastHeight;
                    consecutiveSameHeight++;
                }
                break;
                
            case 3: // Middle focused (easier)
                targetHeight = Random.Range(transform.position.y - heightofset * 0.5f, 
                                           transform.position.y + heightofset * 0.5f);
                break;
                
            default: // Complete randomness
                targetHeight = Random.Range(lowestpoint, hightpoint);
                break;
        }
        
        // AI: Avoid too many pipes at same height (boring)
        if(Mathf.Abs(targetHeight - lastHeight) < 2f && Random.Range(0, 100) < 70)
        {
            targetHeight += Random.Range(-5f, 5f);
            targetHeight = Mathf.Clamp(targetHeight, lowestpoint, hightpoint);
        }
        
        lastHeight = targetHeight;
        
        Instantiate(pipe, new Vector3(transform.position.x, targetHeight, 0), transform.rotation);
    }
}
