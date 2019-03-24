using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeStage : MonoBehaviour
{
    public GameObject tile;
    private GameObject[,] tiles;
    // Start is called before the first frame update
    void Start()
    {
        tiles = new GameObject[5,5];
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
        
    }
}
