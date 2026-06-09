using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class FishArray : MonoBehaviour
{
    public GameObject[] fishes;

    void Start()
    {
        Shuffle(fishes);
    }
    public void Shuffle(GameObject[] fishes)
    {   
        for (int i = fishes.Length-1; i > 0; i--)
        {
            int j = UnityEngine.Random.Range(0, i + 1);
            GameObject temp = fishes[i];
            fishes[i] = fishes[j];
            fishes[j] = temp;
        }
    }

    public List<GameObject> UnShuffled(int min, int max)
    {
        List<GameObject> fishes = new List<GameObject>();
        for (int i = min; i <= max; i++)
        {
            //fishes.Add(i);
        }
        return fishes;
    }
}
