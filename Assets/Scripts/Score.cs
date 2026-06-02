using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{   
    //SCORING
    [SerializeField] public TextMeshProUGUI scoreText;
    public int score;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = " " + score;    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            score++;
        }
    }
}
