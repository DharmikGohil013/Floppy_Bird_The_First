using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private bool isPaused = false;
    public bool slowMotionEnabled = false;
    public float slowMotionScale = 0.5f;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            ToggleSlowMotion();
        }
    }

    public void TogglePause()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    public void ToggleSlowMotion()
    {
        if(slowMotionEnabled)
        {
            Time.timeScale = 1f;
            slowMotionEnabled = false;
        }
        else
        {
            Time.timeScale = slowMotionScale;
            slowMotionEnabled = true;
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0f; // Pause the game by setting the time scale to 0
        isPaused = true;
        // Additional logic to show pause menu, mute audio, etc., can be added here.
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f; // Resume the game by setting the time scale back to 1
        isPaused = false;
        slowMotionEnabled = false;
        // Additional logic to hide pause menu, unmute audio, etc., can be added here.
    }
}
