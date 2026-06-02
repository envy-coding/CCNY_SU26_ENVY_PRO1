using UnityEngine;

public class PlayerWASD : MonoBehaviour
{
    //DECLARE VARIABLES
    //MOVEMENT VARIABLES: SPEED, MOVEMENT
    public float speed;
    public KeyCode LeftKey = KeyCode.A;
	public KeyCode RightKey = KeyCode.D;

    //TRANSFORM OF PLAYER 
	public Transform playerTransform;
	public PlayerWASD myScript;
    public Rigidbody2D RB;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myScript = this; //THIS is a keyword to decribe the scope of the script
		playerTransform = this.gameObject.transform; //GAMEOBJECT is a property of MONOBEHAVIOR //TRANSFORM is a property of all gameobjects
        RB = this.gameObject.GetComponent<Rigidbody2D>();
    }
    
    Vector3 Direction()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            return new Vector3(horizontal, vertical, 0);
        }
    // Update is called once per frame
    void FixedUpdate() //FOR PHYSICS ENGINE
    {
       //ConditionalMoveExample();

       Vector3 direction = Direction();
       direction.y = 0;
       if(direction != Vector3.zero)
        {
            RB.linearVelocity = direction * speed * Time.fixedDeltaTime;
        }
    }

    void ConditionalMoveExample()
    {
        if(Input.GetKey("LeftKey"))
		{
			//playerTransform.position -= Vector3.right * speed * Time.deltaTime;
            RB.linearVelocity = Vector3.right * -speed * Time.deltaTime;
		}

		if(Input.GetKey("RightKey"))
		{
			//playerTransform.position += Vector3.right * speed;
            RB.linearVelocity = Vector3.right * speed * Time.deltaTime;
		}

        if(!Input.GetKey(LeftKey) && !Input.GetKey(RightKey))
        {
            RB.linearVelocity = Vector3.zero;
        } 
    }

   
}
