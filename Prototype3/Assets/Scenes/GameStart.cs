using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    public int startSize;
    public Player1 player1;
    public Player2 player2;
    // Start is called before the first frame update
    void Start()
    {
        var startKeys = new LinkedList<int>();
        for(var i = 0; i < startSize; ++i)
        {
            startKeys.AddFirst(Random.Range(0, 4));
        }
        player1.keys = new LinkedList<int>(startKeys);
        player2.keys = new LinkedList<int>(startKeys);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
