using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipCard : MonoBehaviour
{
    //t�m� skripti k��nt�� kortin ymp�ri kun korttia klikataan
    //t�m�n pit�� teh� yhteisty�t� gamemanagerin kanssa
    //tallentaa oman spriten ja t�m� scripti l�ytyy jokaiselta kortilta. Joten voi tallentaa kuvan scriptiin ja asettaa vain suffle koodissa kuvan jokaselle copylle tai asettaa gameManagerissa tai giveposition koodissa ei viel� p��tetty

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
        gm.flipcardScript = this;

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


    //n�yt� kortti halutun ajan ja lis�� k��nnettyjen korttien m��r��n yksi kun kortti k��nnet��n ja poista yksi kun se menee takaisin v��rinp�in
    IEnumerator flipCard()
    {
        yield return new WaitForSeconds(1);
    }

    IEnumerator WasntCombination()
    {
        StopCoroutine("flipCard");
        yield return new WaitForSeconds(1);
    }

    IEnumerator WasCombination()
    {
        StopCoroutine("flipCard");
        yield return new WaitForSeconds(1);
    }

    //katotaan jos yhdistelm� l�ydetti lopetetaan coroutine  
    //miinustetaan my�s flipped card arvosta
   
}
