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
    public Rigidbody2D RB;
    
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



    void Start()
    {   
        myScript = this; //THIS is a keyword to decribe the scope of the script
		playerTransform = this.gameObject.transform; //GAMEOBJECT is a property of MONOBEHAVIOR //TRANSFORM is a property of all gameobjects
        RB = gameObject.GetComponent<Rigidbody2D>();
       
    }

    void Update()
        {
            
        }
    
    Vector3 Direction()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            return new Vector3(horizontal, vertical, 0);
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
       if (collision.gameObject.tag == "Coin")
       {
            Destroy(collision.gameObject);
            AddScore();
       }

       if (collision.gameObject.tag == "Enemy")
       {
              TakeDamage(damage);
       }
       
    }
   
    void AddScore()
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
}
