using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Shuffle : MonoBehaviour
{
    //sekoittaa jonon miss‰ on korttien kuvat ja t‰m‰ jono sit laitetaan paikallaan olevien korttien spriteksi ja k‰‰nnett‰‰n takaisin, mutta tallenetaan se jotenkin, ett‰ kun kortin k‰‰nt‰‰ se on viel‰ sama kortti

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
