using UnityEngine;
using UnityEngine.AdaptivePerformance;
using System.Collections.Generic;

public class Generator : MonoBehaviour
{   //DECLARE VARIABLES
float timer = 0;
public GameObject[] EnemyFish;

public GameObject BubbleShield;
public GameObject Player;
public Rigidbody2D rB;

public float posX;
public float posY;

public List<FishArray> fishes;

public int spawnCount;

 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnCount = 5;
        StopSpawning();
        rB = GetComponent<Rigidbody2D>();
        Player = GameObject.Find("PLAYER");
        //GameObject[] EnemyFish = FishArray.fishes;
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
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
        ChooseSide();
        if(timer > 0 && spawnCount < 5)
        {
            timer -= Time.deltaTime;
            float posY = Random.Range(-4f, 4f);
            Instantiate(fishes[0], new Vector3(posX, posY, 0), new Quaternion(0, 0, 0, 0));    
        }
        else
        {
            StopSpawning();
        }
    }
}
