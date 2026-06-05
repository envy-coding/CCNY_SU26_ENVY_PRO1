using UnityEngine;

public class EnemyMovement : MonoBehaviour
{   
    public Rigidbody2D rB;
    public Transform tR;

    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rB = GetComponent<Rigidbody2D>();
        tR = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        tR.Translate(Vector3.right * speed * Time.deltaTime);
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
