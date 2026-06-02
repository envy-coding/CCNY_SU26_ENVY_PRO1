using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    //REFERENCES
        //https://youtu.be/POq1i8FyRyQ?si=2fFIfczEWbYO3KSf
    public float timer = 3f;

    public float gameTimer = 20f;
    public GameObject coinPrefab;
    public GameObject player;

    [SerializeField] public TextMeshProUGUI timerText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        int seconds = Mathf.FloorToInt(gameTimer % 60);
        timerText.text = string.Format("{0:00}", seconds);
      
        if (timer < 0)
        {
            Vector3 pos = new Vector3(Random.Range(-8,8), Random.Range(-4,4), 0);
            
            Instantiate(coinPrefab, pos, Quaternion.identity);
            
            timer = 3f;
        }

        if (gameTimer > 0)
        {
            gameTimer -= Time.deltaTime;
            if (gameTimer <= 0)
            {
                player.SetActive(false);
                Debug.Log("Game Over");
            }
        }
    }
}

