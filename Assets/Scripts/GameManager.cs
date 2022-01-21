using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public int lives;
    public int level;

    public GameObject player;

    public GameObject panelPlay;
    public GameObject panelGameOver;

    public GameObject panelGameWin;

    public int levelIndex;

    public Text livesText;
    public Text levelText;

    // Start is called before the first frame update
    public int Lives
    {
        get 
        { 
            return lives;
        }
        set 
        { 
            lives = value; 
            livesText.text = "Lives: " + lives;
        }
    }

    public int Level
    {
        get 
        { 
            return level; 
        }
        set 
        { 
            level = value; 
            levelText.text = "Level: " + level;
        }
    }
 

    void Start()
    {   
        Lives = lives;
        Level = level;
        Level = SceneManager.GetActiveScene().buildIndex + 1;
    }

    // Update is called once per frame
    public void GameOver() {
        panelGameOver.SetActive(true);
    }

    public void GameComplete() {
        Time.timeScale = 0f;
        panelGameWin.SetActive(true);
    }
}
