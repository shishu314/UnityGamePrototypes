using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageControl : MonoBehaviour
{
    public TileState tile;
    private TileState[,] tiles;
    // Start is called before the first frame update
    void Start()
    {
        tiles = new TileState[5,5];
        for(var i = 0; i < 5; ++i)
        {
            for (var j = 0; j < 5; ++j)
            {
                tiles[i,j] = Instantiate(tile, new Vector3(i * 1.0F - 2.5F, j * 1.0F - 4.5F, 0), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(Random.Range(1,100) < 10)
        {
            var x = Random.Range(0, 4);
            var y = Random.Range(0, 4);
            while(tiles[x,y].State != "Neutral")
            {
                x = Random.Range(0, 4);
                y = Random.Range(0, 4);
            }
            var stateRand = Random.Range(1, 3);
            switch(stateRand)
            {
                case 1:
                    tiles[x, y].State = "Water";
                    break;
                case 2:
                    tiles[x, y].State = "Lava";
                    break;
                case 3:
                    tiles[x, y].State = "Poison";
                    break;
                default:
                    break;
            }
        }
        */
    }
}
