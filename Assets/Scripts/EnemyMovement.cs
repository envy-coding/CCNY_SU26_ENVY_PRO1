using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{   
    public Rigidbody2D enemyRB;
    //public Transform enemyTR;
    private bool isMoving;

    public GameObject Player;
    public bool PlayerAlive;
    public float speed = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { PlayerAlive = true;
      isMoving = true;
        //enemyTR = this.gameObject.transform;
        enemyRB = GetComponent<Rigidbody2D>();
        //enemyTR = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
      {
        OnPlayerDeath();
        //enemyTR.Translate(Vector3.right * speed * Time.deltaTime);
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
