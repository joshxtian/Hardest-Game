using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviour
{
    public GameObject gameManager;
    private GameManager manager;


    void Start() {
        manager = gameManager.GetComponent<GameManager>();
        
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Player") {
            Time.timeScale = 0f;
            manager.GameComplete();
        }
    }

   
}
