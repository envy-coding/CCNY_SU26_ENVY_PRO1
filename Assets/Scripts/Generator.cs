using UnityEngine;
using UnityEngine.AdaptivePerformance;

public class Generator : MonoBehaviour
{   //DECLARE VARIABLES
float timer = 0;
public GameObject[] EnemyFish;
public GameObject BubbleShield;
public GameObject Player;
public Rigidbody2D rB;

public float posX;
public float posY;

public Vector3 enemyPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StopSpawning();
        rB = GetComponent<Rigidbody2D>();
        Player = GameObject.Find("Player");
        enemyPosition = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        ChooseSide();
        Spawn();
    }

    public void StopSpawning()
    {
        if(Player.GetComponent<PlayerWASD>().isAlive == false)
        {
            timer = 100f;
        }
    }

    public void ChooseSide()
    {
        int sideChance = Random.Range(1, 101);
        
        
        
        if(sideChance <= 50)
        {
            posX = -7f;
        }
        else
        {
            posX = 7f;
        }
        
        
    }

    public void Spawn()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            int chance = Random.Range(1, 101);
            float posY = Random.Range(-5f, 5f);
            float posX = Random.Range(-7,7);

            if(chance <= 20)
            {
                Instantiate(EnemyFish[1], new Vector3(posX, posY, 0), new Quaternion(0, 0, 0, 0));
            }

            
            {
                Instantiate(EnemyFish[2], new Vector3(posX, posY, 0), new Quaternion(0, 0, 0, 0));
            }
        
        }
    }
}
