using System.Collections.Generic;
using UnityEngine;

public class FishArray : MonoBehaviour
{
    public int[] fishes;

    void Start()
    {
        Shuffle(fishes);
    }
    public void Shuffle(int[] a)
    {   
        for (int i = a.Length-1; i > 0; i--)
        {
            int random = Random.Range(0,1);
            int temp = a[i];
            a[i] = a[random];
            a[random] = temp;
        }
    }
}
