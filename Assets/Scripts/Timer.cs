using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timer = 2f;

    public float gameTimer = 60f;
    public GameObject object;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
      
        if (timer < 0)
        {
            Vector3 pos = new Vector3(Random.Range(-8,8), Random.Range(-4,4), 0);
            Instantiate(object, pos, Quaternion.identity);
            timer = 3f;
        }

        if (gameTimer > 0)
        {
            gameTimer -=
        }
    }
}
