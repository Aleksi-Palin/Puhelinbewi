using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Shuffle : MonoBehaviour
{

    public List<GameObject> Items;

    public static System.Random rng = new System.Random();

    public void shuffle(List<GameObject> list)
    {

        int n = list.Count;

        while(n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            GameObject value = list[k];
            list[k] = list[n];
            list[n] = value;

        }
    }

    private void Start()
    {
        shuffle(Items);

        foreach (var item in Items){
            print(item.name);
        }
    }

}
