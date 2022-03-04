using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipCard : MonoBehaviour
{
    //t‰m‰ skripti k‰‰nt‰‰ kortin ymp‰ri kun korttia klikataan
    //t‰m‰n pit‰‰ teh‰ yhteistyˆt‰ playercontrollerin kanssa

    private GameManager gm;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    private void OnMouseDown()
    {
        
        if (gm.FirstCard == string.Empty)
        {
            gm.FirstCard = this.gameObject.name;

            gm.FirstCardIsFlipped = true;
            print("wat");
        }
        else
        {
            gm.SecondCard = gameObject.name;
        }
        gm.CheckForCombo();
    }
}
