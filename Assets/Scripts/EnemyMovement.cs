using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{   
    public Rigidbody2D enemyRB;
    //public Transform enemyTR;
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
      //enemyTR = this.gameObject.transform;
      enemyRB = GetComponent<Rigidbody2D>();
      //enemyTR = GetComponent<Transform>();
      
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
}
