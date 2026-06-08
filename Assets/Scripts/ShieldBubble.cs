using UnityEngine;

public class ShieldBubble : MonoBehaviour
{
    //DECLARE VARIABLES
    public Transform bubbleTransform;
    public Rigidbody2D bubbleRigidbody;

    //WAVE VARIABLES
    private int amplitude = 1;
    private int frequency = 4;

    public GameObject BubbleShield;

    void Start()
    {
        bubbleTransform = GetComponent<Transform>();
    }

    void Update()
    {
       bubbleTransform.Translate(Vector3.up * 2f * Time.deltaTime);
      
       //DEFINE POSITION
       float x = Mathf.Cos(Time.time * frequency) * amplitude; 
       float y = this.transform.position.y;
       float z = this.transform.position.z;

       //SETTING POSITION
       this.bubbleTransform.position = new Vector3(x, y, z);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ceiling"))
        {
            Destroy(gameObject);
        }
    }
}
