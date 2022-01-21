using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 moveDirection;

    private AudioSource death;
    Vector2 initialPos;

    public GameObject gameManager;
    private GameManager manager;
    public GameObject player;
    private PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        initialPos = this.transform.position;
        manager = gameManager.GetComponent<GameManager>();
        death = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
      ProcessInput();  
    }

    void FixedUpdate() 
    {
        Move();
       
    }

    void ProcessInput()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveX, moveY).normalized;

    }

    void Move() 
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed); 
    }

    void ResetPosition() {
        this.transform.position = initialPos;
        
    }

    
    public void OnTriggerEnter2D(Collider2D collision) {
        
        if(collision.tag == "Enemy" || collision.tag == "Wall") {
            
            if(manager.Lives == 1 || manager.Lives < 1) {
                Time.timeScale = 0f; 
                manager.GameOver();
            } else {
                death.Play();
                manager.Lives -= 1;  
                ResetPosition();
            } 
        } else if (collision.tag == "GameFinish") {
            
            manager.GameComplete();
        }
    }


}
