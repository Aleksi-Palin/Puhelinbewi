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

    private bool WacCR_Running;

    private bool Scwc_Running;

    private void Start()
    {
        

        gm = FindObjectOfType<GameManager>();
        SR = GetComponent<SpriteRenderer>();

        CardsBackside_Image = gm.CardBackSide;

        Card_ShowTime = gm.WaitTime;
    }

    private void OnMouseDown()
    {
        if (gm.CardsFlipped < 2 && !CardIsFlipped)
        {
            StartCoroutine("ShowCardWhenClicked");

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
    IEnumerator ShowCardWhenClicked()
    {
        Scwc_Running = true;

        CardIsFlippedCache = true;
        SR.sprite = CardImage;
        gm.CardsFlipped += 1;
        CardIsFlipped = true;

        
        yield return new WaitForSeconds(Card_ShowTime);

        CardIsFlipped = false;
        SR.sprite = CardsBackside_Image;
        gm.CardsFlipped -= 1;
        CardIsFlippedCache = false;

        Scwc_Running = false;
    }

    public IEnumerator WasntACombination()
    {
        WacCR_Running = true;
        StopCoroutine("ShowCardWhenClicked");

        
        yield return new WaitForSeconds(1);
        if (CardIsFlipped && CardIsFlippedCache)
        {
            SR.sprite = CardsBackside_Image;
            gm.CardsFlipped -= 1;
            CardIsFlipped = false;
        }

        WacCR_Running = false;
    }

    //katotaan jos yhdistelmä löydetti lopetetaan coroutine  
    //miinustetaan myös flipped card arvosta
    private void Update()
    {
       if(!gm.Combination_Found && gm.CardsFlipped == 2 && !WacCR_Running)
        {
            StartCoroutine("WasntACombination");
        } else if(gm.Combination_Found && gm.CardsFlipped == 2 && !Scwc_Running)
        {
            StopCoroutine("ShowCardWhenClicked");
           

            

        }
    }
}
