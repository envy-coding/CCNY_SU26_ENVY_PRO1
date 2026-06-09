using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class EnemyMovement : MonoBehaviour
{   
    public Rigidbody2D enemyRB;
    private bool isMoving;

    public GameObject Player;
    public bool PlayerAlive;
    
    public float speed;
    private GameObject smallFish;
    private GameObject mediumFish;
    private GameObject largeFish;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
      PlayerAlive = true;
      isMoving = true;
      
      enemyRB = GetComponent<Rigidbody2D>();
      
      
      smallFish = GameObject.Find("SmallEnemy");  
      mediumFish = GameObject.Find("MediumEnemy");
      largeFish = GameObject.Find("LargeFish");


    }

    // Update is called once per frame
    void Update()
      {
        Speed();
        OnPlayerDeath();
        //enemyTR.Translate(Vector3.right * speed * Time.deltaTime);
      }

    void Speed()
  {
      if (this.gameObject == smallFish)
      {
        speed = 2f;
      }

      else if (this.gameObject == mediumFish)
      {
        speed = 5f;
      }

      else 
      {
        speed = 8f;
      }
  } 

    void FixedUpdate()
    {
      if(PlayerAlive && isMoving) 
      { 
        float posX = 2f * speed;   
        enemyRB.linearVelocity = new Vector3(posX, 0, 0);
      }
    }

    void OnPlayerDeath()
    {
      if(Player == null)
      {
        PlayerAlive = false;
      }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (this.gameObject == smallFish)
        {
          if(collision.gameObject == smallFish)
          {
            Destroy(collision.gameObject);
          }
          if(collision.gameObject == mediumFish)
          {
            Destroy(this.gameObject);
          }
          if(collision.gameObject == largeFish)
          {
            Destroy(this.gameObject);
          }
        }
        
        if (this.gameObject == mediumFish)
        {
          if(collision.gameObject == smallFish)
          {
            Destroy(collision.gameObject);
          }
          if(collision.gameObject == mediumFish)
          {
            Destroy(collision.gameObject);
          }
          if(collision.gameObject == largeFish)
          {
            Destroy(this.gameObject);
          }
        }
        
        if (this.gameObject == largeFish)
        {
          if(collision.gameObject == smallFish)
          {
            Destroy(collision.gameObject);
          }
          if(collision.gameObject == mediumFish)
          {
            Destroy(collision.gameObject);
          }
          if(collision.gameObject == largeFish)
          {
            Destroy(collision.gameObject);
          }
        }
    }
}
