using UnityEngine;
using TMPro;

public class PlayerWASD : MonoBehaviour
{
    //DECLARE VARIABLES
    
    //MOVEMENT VARIABLES: SPEED, MOVEMENT
    public float speed = 200f;
    public KeyCode LeftKey = KeyCode.A;
	public KeyCode RightKey = KeyCode.D;

    //TRANSFORM OF PLAYER 
	public Transform playerTransform;
	public PlayerWASD myScript;
    public Rigidbody2D RB;
    
    //JUMP VARIABLES
    public float jumpTimer = 0.3f;
    public bool grounded;
    public float jumpForce = 100f;

    //SCORING
    [SerializeField] public TextMeshProUGUI scoreText;
    public int score;

    void Start()
    {   
        myScript = this; //THIS is a keyword to decribe the scope of the script
		playerTransform = this.gameObject.transform; //GAMEOBJECT is a property of MONOBEHAVIOR //TRANSFORM is a property of all gameobjects
        RB = gameObject.GetComponent<Rigidbody2D>();
       
    }

    void Update()
        {
            if(Input.GetKey(KeyCode.Space))
            {   
                jumpTimer = .1f;
            }

            if(jumpTimer >= 0f)
            {
                jumpTimer -= Time.deltaTime;
            }
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
        direction.y = 0;
        if(direction != Vector3.zero)
            {
                RB.linearVelocity = direction * speed * Time.fixedDeltaTime;
            }

        if(jumpTimer > 0f && grounded)
        {
            Jump(jumpForce);
            jumpTimer = 0f;
        }
    }
    
    

    void Jump(float jumpForce)
    {
        RB.AddForce(Vector3.up * jumpForce);
    }

    //COINBUMP
    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.tag == "Coin")
       {
            Destroy(collision.gameObject);
            AddScore();
       }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        grounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        grounded = false;
    }
   
    void AddScore()
    {
        scoreText.text = " " + score;
        score++;
    }
}
