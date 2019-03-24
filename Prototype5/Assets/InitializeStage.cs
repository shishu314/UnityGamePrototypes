using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeStage : MonoBehaviour
{
    public GameObject tile;
    // Start is called before the first frame update
    void Start()
    {
        for(var i = -5; i < 5; ++i)
        {
            for (var j = -5; j < 5; ++j)
            {
                Instantiate(tile, new Vector3(i * 0.5F, j * 0.5F, 0), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
