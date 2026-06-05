using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class WrapScript : MonoBehaviour
{
    //DECLARE VARIABLES
    public Rigidbody2D rB;

    void Start()
    {
        rB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {   
        //DECLARE SCREEN POSITION
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position); //GET SCREEN POSITION OF OBJECT IN PIXELS
       
        //DECLARE SIDES OF SCREEN
        float rightSideOfScreenInWorld = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x; //GET POSITION OF RIGHT SIDE OF SCREEN IN WORLD UNITS, X-VALUE
        float leftSideOfScreenInWorld = Camera.main.ScreenToWorldPoint(new Vector2(0f, 0f)).x; //GET POSITION OF LEFT SIDE OF SCREEN IN WORLD UNITS, X-VALUE
        float topSideOfScreenInWorld = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).y; //GET POSITION OF TOP SIDE OF SCREEN IN WORLD UNITS, Y-VALUE
        float bottomSideOfScreenInWorld = Camera.main.ScreenToWorldPoint(new Vector2(0f, 0f)).y; //GET POSITION OF BOTTOM SIDE OF SCREEN IN WORLD UNITS, Y-VALUE

        //LEFT SIDE
        if(screenPosition.x <= 0 && rB.linearVelocity.x < 0) //IF SCREENPOSITION.X IS LESSTHAN/EQUAL TO ZERO && MOVING TO THE LEFT
            {transform.position = new Vector2(rightSideOfScreenInWorld, transform.position.y);} //SET POSITION TO RIGHT SIDE, SAME Y
        //RIGHT SIDE
        else if(screenPosition.x >= Screen.width && rB.linearVelocity.x > 0) //IF SCREENPOSITION>X IS GREATER THAN SCREEN.WIDTH && MOVING TO THE RIGHT
            {transform.position = new Vector2(leftSideOfScreenInWorld, transform.position.y);}
        //BOTTOM SIDE
        else if(screenPosition.y <= 0 && rB.linearVelocity.y < 0) 
            {transform.position = new Vector2(transform.position.x, topSideOfScreenInWorld);}
        //TOP SIDE
        else if(screenPosition.y >= Screen.height && rB.linearVelocity.y > 0)
            {transform.position = new Vector2(transform.position.x, bottomSideOfScreenInWorld);}
    }
}
