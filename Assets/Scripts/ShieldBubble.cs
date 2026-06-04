using UnityEngine;

public class ShieldBubble : MonoBehaviour
{
    //DECLARE VARIABLES
    Transform tR;
    Rigidbody2D rB;

    //WAVE VARIABLES
    private int amplitude = 1;
    private int frequency = 4;

    void Start()
    {
        tR = GetComponent<Transform>();
    }

    void Update()
    {
       tR.Translate(Vector3.up * 2f * Time.deltaTime);
      
       //DEFINE POSITION
       float x = Mathf.Cos(Time.time * frequency) * amplitude; 
       float y = this.transform.position.y;
       float z = this.transform.position.z;

       //SETTING POSITION
       this.tR.position = new Vector3(x, y, z);
    }

    private void OncollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ceiling"))
        {
            Destroy(gameObject);
        }

        if(other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Shield();
        }
    }

    void Shield()
    {
        
    }
}
