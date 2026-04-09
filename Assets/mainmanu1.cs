using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmanu1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            stopgame();
        }
        if(Input.GetKeyDown(KeyCode.Return))
        {
            playgame();
        }
    }
    
    public void playgame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(1);
    }
    public void stopgame()
    {
        Application.Quit();
    }
   
}
