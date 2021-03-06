using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveCardsPositions : MonoBehaviour
{

    //This script give every card position in the scene


    //IDEA T?LLE SCRIPTILLE!!
    //Annetaan Maximi boundarit eli reunat mink? yli ei voi menn? ja scripti laittaa kortit tasaisin margini v?lein halutulle v?lille korttien mittojen perusteella. (T?h?n tarvitaan kortin x & y mitat) (maximi boundarit koskee my?s Y akselia)
    //scriptille my?s annetaan mink? kokoiseksi arvaus alusta halutaan mm. 4x4, 8x8, 16x16 yms. jolloin se asettaa kortita oikein (Miten? en tied? googlaa)

    [SerializeField]
    private int rows;
    [SerializeField]
    private int cols;
    [SerializeField]
    private float tileSize = 1;

    private Shuffle shuffleScript;

    private int CardNumber = 0;

    private void Start()
    {
        shuffleScript = FindObjectOfType<Shuffle>();
        
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        
        GameObject ReferenceTile = (GameObject)Instantiate(Resources.Load("SampleCard"));
        for (int  row = 0;  row < rows;  row++)
        {
            for (int col = 0; col < cols; col++)
            {
                GameObject tile = (GameObject)Instantiate(ReferenceTile, transform);

                tile.GetComponent<FlipCard>().CardImage = shuffleScript.Items[CardNumber];

                float posX = col * tileSize;
                float posY = row * -tileSize;

                tile.transform.position = new Vector2(posX, posY);

                CardNumber++;
            }
        }
        Destroy(ReferenceTile);

        float GridW = rows * tileSize;
        float GridH = cols * tileSize;

        transform.position = new Vector2(-GridW / 2 + tileSize / 2, GridH / 2 - tileSize / 2);

    }

}
