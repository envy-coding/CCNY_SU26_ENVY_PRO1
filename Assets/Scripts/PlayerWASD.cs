using UnityEngine;
using TMPro;

public class PlayerWASD : MonoBehaviour
{
    //DECLARE VARIABLES
    
    //MOVEMENT VARIABLES: SPEED, MOVEMENT
    public float speed = 200f;
    
    //TRANSFORM OF PLAYER 
	public Transform playerTransform;
	public PlayerWASD myScript;
     Rigidbody2D RB;
     Collider2D coll;
     GameObject player;
    
    
    //JUMP VARIABLES
    //public float jumpTimer = 0.3f;
    //public bool grounded;
    //public float jumpForce = 100f;

    //SCORING
    [SerializeField] public TextMeshProUGUI scoreText;
    public int score;

    //HEALTH
    public bool isAlive;
    public int lives = 3;

    //DAMAGE
    public int damage = 1;

    //SHIELD
    public bool shieldOn;
    [SerializeField] private GameObject shield;

   


    void Start()
    {  
       Initialization();
    }

    void Update()
    {
        //PlayerSize();  
    
    }
    
    public Vector3 Direction()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            
            return new Vector3(horizontal, vertical, 0);
        }
    
    void Initialization()
    {
        shieldOn = false;
        myScript = this; //THIS is a keyword to decribe the scope of the script
		playerTransform = this.gameObject.transform; //GAMEOBJECT is a property of MONOBEHAVIOR //TRANSFORM is a property of all gameobjects
        RB = gameObject.GetComponent<Rigidbody2D>();
        coll = gameObject.GetComponent<Collider2D>();
        
    }
    void FixedUpdate() //FOR PHYSICS ENGINE
    {
        Vector3 direction = Direction();
        //direction.y = 0;
        if(direction != Vector3.zero)
            {
                RB.linearVelocity = direction * speed * Time.fixedDeltaTime;
            }

    }

    //COINBUMP
    public void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.tag == "Enemy")
       {
            Destroy(collision.gameObject);
            AddScore();
       }

       if(collision.gameObject.tag == "Bubble")
        {
            Destroy(collision.gameObject);
            shield.SetActive(true);
            shieldOn = true;
            Invoke("ShieldOff", 3f); //INVOKE SHIELD OFF AFTER 3 SECONDS
        }
    }

    void ShieldOff()
    {
        shield.SetActive(false);
        shieldOn = false;
    }

    public void On2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            RB.linearVelocity = Vector2.zero;
        }
    }

    public void AddScore()
    {
        scoreText.text = " " + score;
        score++;
    }

    public void Die()
    {
        isAlive = false;
        RB.linearVelocity = Vector2.zero;
    }

    public void TakeDamage(int damage)
    {
        lives -= damage;

        if (lives == 0)
        {
            Die();
        }
    }

    //public void PlayerSize()
    //{
     //   if(score < 3)
      //  {
      //      player.transform.localScale = new Vector3(1, 1, 0);
       // }
       // if(score < 6)
       // {
     //       player.transform.localScale = new Vector3(2, 1, 0);
    //
      //  }
       // if(score < 9)
       // {
 //           player.transform.localScale = new Vector3(2, 2, 0);

   //     }
    }

