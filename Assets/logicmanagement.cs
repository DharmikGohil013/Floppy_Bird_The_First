using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class logicmanagement : MonoBehaviour
{
    public int playerscore;
    public TextMeshProUGUI socore;
    public GameObject gameoverscree;
    public int scorePerPipe = 5;
    public float scoreMultiplier = 2f;
    public int comboCount = 0;
    public float comboBonus = 1.5f;
    
    [ContextMenu("increse score")]  
    public void aaddscore()
    {
        comboCount++;
        float totalMultiplier = scoreMultiplier * (1 + (comboCount * 0.1f));
        int scoreToAdd = Mathf.RoundToInt(scorePerPipe * totalMultiplier);
        playerscore = playerscore + scoreToAdd;
        socore.text=playerscore.ToString();
    }
    public void restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void gameover()
    {
        gameoverscree.SetActive(true);
    }

}
