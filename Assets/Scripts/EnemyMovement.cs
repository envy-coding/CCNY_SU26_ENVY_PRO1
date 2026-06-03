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
        
    }
}
