using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveCardsPositions : MonoBehaviour
{

    //This script give every card position in the scene


    //IDEA TÄLLE SCRIPTILLE!!
    //Annetaan Maximi boundarit eli reunat minkä yli ei voi mennä ja scripti laittaa kortit tasaisin margini välein halutulle välille korttien mittojen perusteella. (Tähän tarvitaan kortin x & y mitat) (maximi boundarit koskee myös Y akselia)
    //scriptille myös annetaan minkä kokoiseksi arvaus alusta halutaan mm. 4x4, 8x8, 16x16 yms. jolloin se asettaa kortita oikein (Miten? en tiedä googlaa)

    [SerializeField]
    private int rows = 5;
    [SerializeField]
    private int cols = 8;
    [SerializeField]
    private float tileSize = 1;

    private void Start()
    {
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

                float posX = col * tileSize;
                float posY = row * -tileSize;

                tile.transform.position = new Vector2(posX, posY);
            }
        }
        Destroy(ReferenceTile);

        float gridW = cols * tileSize;
        float gridH = rows * tileSize;

        transform.position = new Vector2(gridW / 2 + tileSize / 2, gridH / 2 - tileSize / 2);

    }

}
