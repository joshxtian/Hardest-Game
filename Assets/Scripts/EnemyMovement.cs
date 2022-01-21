using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed;
    public bool isMovingX;
    public bool firstMoveLeft;

    public bool firstMoveUp;

    private int xLeft = -1;
    private int xRight = 1;
    private int yUp = 1;
    private int yDown = -1;
  

    // private int lives;
    private Vector2 moveDirection;
    public Rigidbody2D rb;
    // public GameObject gameManager;
    // public GameManager manager;
    // public GameObject player;
    // public PlayerMovement playerMovement;
    

    // Start is called before the first frame update
    void Start()
    {   
      
        // manager = gameManager.GetComponent<GameManager>();
        // manager.lives -= 1;

        // Debug.Log(manager.lives);
        // Time.timeScale = 1f; 
        Move();
    }

    // Update is called once per frame
    
    private void Awake() 
    {

    }

     void FixedUpdate()
    {
        rb.velocity = rb.velocity.normalized * moveSpeed;
        moveDirection = rb.velocity;
    }


    void Move() 
    {   
        if(isMovingX) {
            if(firstMoveLeft) {
                moveDirection = new Vector2(xLeft, 0).normalized;
            } 
            else {
                moveDirection = new Vector2(xRight, 0).normalized;
            }
        } 
        else {
            if(firstMoveUp) {
                moveDirection = new Vector2(0, yUp).normalized;
                
            }
            else {
                moveDirection = new Vector2(0, yDown).normalized;
            }
        }
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed); 
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        rb.velocity = Vector2.Reflect(moveDirection, collision.contacts[0].normal);
    }

    // public void OnTriggerEnter2D(Collider2D collision) {
    //     if(collision.tag == "Player") {
 
    //         Time.timeScale = 0f;
    //     }
    // }


}
