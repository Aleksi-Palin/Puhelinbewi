using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Shuffle : MonoBehaviour
{
    //sekoittaa jonon miss‰ on korttien kuvat ja t‰m‰ jono sit laitetaan paikallaan olevien korttien spriteksi ja k‰‰nnett‰‰n takaisin, mutta tallenetaan se jotenkin, ett‰ kun kortin k‰‰nt‰‰ se on viel‰ sama kortti
    public string Wanted_Prefab_Folder;

    public List<Sprite> Items;

    public static System.Random rng = new System.Random();

    public void shuffle(List<Sprite> list)
    {

        int n = list.Count;

        while(n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            Sprite value = list[k];
            list[k] = list[n];
            list[n] = value;

        }
    }

    private void Start()
    {
        //otetaan kaikki prefabit halutusta kansiosta ja siirrett‰‰n ne eri muotoisesta listasta toiseen 
        for (int i = 0; i < 2; i++)
        {
            Sprite[] CacheItems = Resources.LoadAll<Sprite>(Wanted_Prefab_Folder);

            foreach (var CacheItem in CacheItems)
            {
                Items.Add(CacheItem);
            }
        }
        
        //sekoitetaan kortit
        shuffle(Items);



    }

}
