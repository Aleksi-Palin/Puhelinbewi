using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //t‰ss‰ scriptiss‰ checkataan jos 2 samaa korttia on k‰‰nnetty oikein p‰in ja jos on niin ne j‰‰ oikein p‰in
    //t‰m‰ tehd‰‰n tsekkaamlla klikatun kortin nimi ja jos tietyss‰ aika ikkunassa saman niminen kortti klikataan myˆs ne j‰‰ oikein p‰in

    [Header("Timer")]
    [SerializeField]
    public float WaitTime;

    [Header("Booleans")]
    
    public bool FirstCardIsFlipped;

    public bool Combination_Found;
    public bool NoCombination;

    [Header("Flipped Card count")]
    public int CardsFlipped;

    [Header("Flipped Cards")]
    public string FirstCard;
    public string SecondCard;

    [Header("Instance")]
    private static GameManager Instance;

    [Header("Cards backside sprite")]
    public Sprite CardBackSide;

    [Header("Other scipts")]
    private FlipCard flipcardScript;

    private void Start()
    {
        Instance = FindObjectOfType<GameManager>();

        if(Instance != null)
        {
            return;
        }

        Instance = this;
        NoCombination = true;
        //flipcardScript = FindObjectOfType<FlipCard>();

    }

    private void Update()
    {

        //onko eka kortti k‰‰nnetty
        if (FirstCardIsFlipped)
        {
            //jos aika on isompi kuin 0
            if(WaitTime > 0)
            {
                //onko klikatut kortit combo?
                if(FirstCard == SecondCard)
                {
                    Combination_Found = true;
                    NoCombination = false;
                }
                else
                {
                    NoCombination = true;
                    
                    if(CardsFlipped == 2)
                    {
                        
                        WaitTime = 0f;
                    } 

                }

                WaitTime -= Time.deltaTime;
            }
            else
            {
                print("aika loppu");
                FirstCard = string.Empty;
                SecondCard = string.Empty;
                WaitTime = 4f;
                FirstCardIsFlipped = false;
                Combination_Found = false;
                NoCombination = true;
            }

            
        }
    }


    //katotaan ett‰ jos ensimm‰inen kortti on k‰‰nnetty odotettaan 2 sekunttia toista korttia varten ja katotaan onko ne sama kortti ja jos ei k‰‰nnet‰‰n ne takaisin jos on samna niin j‰‰ oikein p‰in.
    
}
