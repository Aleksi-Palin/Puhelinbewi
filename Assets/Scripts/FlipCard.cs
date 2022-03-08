using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipCard : MonoBehaviour
{
    //tämä skripti kääntää kortin ympäri kun korttia klikataan
    //tämän pitää tehä yhteistyötä gamemanagerin kanssa
    //tallentaa oman spriten ja tämä scripti löytyy jokaiselta kortilta. Joten voi tallentaa kuvan scriptiin ja asettaa vain suffle koodissa kuvan jokaselle copylle tai asettaa gameManagerissa tai giveposition koodissa ei vielä päätetty

    private GameManager gm;

    private SpriteRenderer SR;

    [Header("Card Images/sprites")]
    public Sprite CardsBackside_Image;
    public Sprite CardImage;

    [Header("Show time")]

    [SerializeField] float Card_ShowTime;

    [Header("Booleans")]

    [SerializeField] private bool CardIsFlipped;
    private bool CardIsFlippedCache;

    private bool WasntC_CR_Running;

    private bool FC_CR_Running;

    private bool WasC_CR_Running;

    private bool CardCountsubtracted;


    
    private void Start()
    {
        

        gm = FindObjectOfType<GameManager>();
        SR = GetComponent<SpriteRenderer>();

        CardsBackside_Image = gm.CardBackSide;

        Card_ShowTime = gm.WaitTime;
    }

    private void OnMouseDown()
    {
        gm.flipcardScript = this;

        if (gm.CardsFlipped < 2 && !FC_CR_Running)
        {
            StartCoroutine("flipCard");

            //laitaan ekan klikatun kortin nimeksi kuvan nimi
            //ja jos eka kortti onjo klikattu laittaa se sen toisen klikatun stringiin
            if (gm.FirstCard == string.Empty)
            {
                gm.FirstCard = CardImage.name;

                gm.FirstCardIsFlipped = true;

            }
            else
            {
                gm.SecondCard = CardImage.name;
            }
        }
         
    }


    //näytä kortti halutun ajan ja lisää käännettyjen korttien määrään yksi kun kortti käännetään ja poista yksi kun se menee takaisin väärinpäin

    //tee booleaneita jotka tarkistavat eri vaiheita, jotta ei tule bugeja jos käyttäjä tekee jotain nopeammin tai hitaammin halutusta nopeudesta.
    IEnumerator flipCard()
    {
        FC_CR_Running = true;

        gm.CardsFlipped++;

        SR.sprite = CardImage;

        yield return new WaitForSeconds(gm.WaitTime);

        gm.CardsFlipped--;

        CardCountsubtracted = true;

        SR.sprite = CardsBackside_Image;

        FC_CR_Running = false;
    }

    IEnumerator WasntCombination()
    {
        WasntC_CR_Running = true;

        StopCoroutine("flipCard");
        FC_CR_Running = false;
        
        yield return new WaitForSeconds(1);

        if (SR.sprite.name == CardImage.name)
        {
            SR.sprite = CardsBackside_Image;
        }

        if (!CardCountsubtracted)
        {
            gm.CardsFlipped--;
        }

        WasntC_CR_Running = false;
    }

    IEnumerator WasCombination()
    {
        WasC_CR_Running = true;

        StopCoroutine("flipCard");

        FC_CR_Running = false;

        SR.sprite = CardImage;

        if (!CardCountsubtracted)
        {
            gm.CardsFlipped--;
        }

        yield return new WaitForSeconds(1);

        WasC_CR_Running = false;
    }

    //katotaan jos yhdistelmä löydetti lopetetaan coroutine  
    //miinustetaan myös flipped card arvosta
   
}
