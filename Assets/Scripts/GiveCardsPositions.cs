using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveCardsPositions : MonoBehaviour
{

    //This script give every card position in the scene


    //IDEA T�LLE SCRIPTILLE!!
    //Annetaan Maximi boundarit eli reunat mink� yli ei voi menn� ja scripti laittaa kortit tasaisin margini v�lein halutulle v�lille korttien mittojen perusteella. (T�h�n tarvitaan kortin x & y mitat) (maximi boundarit koskee my�s Y akselia)
    //scriptille my�s annetaan mink� kokoiseksi arvaus alusta halutaan mm. 4x4, 8x8, 16x16 yms. jolloin se asettaa kortita oikein (Miten? en tied� googlaa)

    [Header("Boundary Values")]
    public BoxCollider2D Bounder;

    private float BoundX;
    private float BoundY;

    [Header("Card size example")]
    public GameObject CardSample;

    private float CardSizeX;
    private float CardSizeY;

    [Header("Grid size")]
    public int SizeX;
    public int SizeY;

    private void Start()
    {
        BoundX = Bounder.size.x;
        BoundY = Bounder.size.y;

        CardSizeX = CardSample.GetComponent<BoxCollider2D>().size.x;
        CardSizeY = CardSample.GetComponent<BoxCollider2D>().size.y;
    }


}
