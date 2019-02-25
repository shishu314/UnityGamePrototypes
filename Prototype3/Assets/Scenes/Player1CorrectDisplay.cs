using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1CorrectDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] Player1CorrectSprites;
    public Player1 player1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(var i = 0; i < player1.correctCount; ++i)
        {
            Player1CorrectSprites[i].GetComponent<SpriteRenderer>().enabled = true;
        }
        for (var i = player1.correctCount; i < Player1CorrectSprites.Length; ++i)
        {
            Player1CorrectSprites[i].GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
