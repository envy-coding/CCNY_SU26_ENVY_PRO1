using UnityEngine;

public class EnemyMovement : MonoBehaviour
{   
    public Rigidbody2D enemyRB;
    public Transform enemyTR;

    public float speed = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyTR = this.gameObject.transform;
        enemyRB = GetComponent<Rigidbody2D>();
        enemyTR = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyTR.Translate(Vector3.right * speed * Time.deltaTime);
    }

    //void SpeedCheck() //SMALL FISH SLOW BIG FISH FAST
    //{
       // if (smallFish)
        //{
         //   speed = 1f;
        //}

        //if (mediumFish)
        //{
          //  speed = 2f;
        //}

        //if (largeFish)
        //{
        //    speed = 3f;
      //  }
    //}

    public void OnCollisionEnter2D(Collision2D collision)
  {
    if(collision.gameObject.name == "smallFish")
    {
      
    }
  }
}
