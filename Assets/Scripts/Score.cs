using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Score : MonoBehaviour
{
    
    //REFERENCES
        //https://youtu.be/YUcvy9PHeXs?si=V-FxEfwnGEogO97h
    
    public static Score instance;
    
    [SerializeField] public TextMeshProUGUI scoreText;
    public int score = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        scoreText.text = " " + score;
    }

    // Update is called once per frame
    public void AddPoint()
    {
        score++;
        scoreText.text = " " + score;
    }
}
