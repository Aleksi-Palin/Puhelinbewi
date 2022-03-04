using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //t‰ss‰ scriptiss‰ checkataan jos 2 samaa korttia on k‰‰nnetty oikein p‰in ja jos on niin ne j‰‰ oikein p‰in
    //t‰m‰ tehd‰‰n tsekkaamlla klikatun kortin nimi ja jos tietyss‰ aika ikkunassa saman niminen kortti klikataan myˆs ne j‰‰ oikein p‰in

    [Header("Timer")]
    [SerializeField]
    private float WaitTime = 2.0f;

    [Header("Booleans")]
    [SerializeField]
    public bool FirstCardIsFlipped;

    [Header("Flipped Cards")]
    public string FirstCard;
    public string SecondCard;

    [Header("Instance")]
    private static GameManager Instance;

    private void Start()
    {
        Instance = FindObjectOfType<GameManager>();

        if(Instance != null)
        {
            return;
        }

        Instance = this;

        
        WaitTime = 2f;
    }

    private void Update()
    {
        //print(FirstCard + " " + SecondCard);
    }


    //katotaan ett‰ jos ensimm‰inen kortti on k‰‰nnetty odotettaan 2 sekunttia toista korttia varten ja katotaan onko ne sama kortti ja jos ei k‰‰nnet‰‰n ne takaisin jos on samna niin j‰‰ oikein p‰in.
    public void CheckForCombo()
    {
        //print("before loop");
        while (FirstCardIsFlipped)
        {
            if (FirstCard == SecondCard)
            {
                print("found combo");
            }


            if (WaitTime > 0)
            {
                
                WaitTime -= Time.deltaTime;
            }
            else
            {
                
                //WaitTime = 2f;
                FirstCardIsFlipped = false;
                
            }

            
        }
        
    }
}
