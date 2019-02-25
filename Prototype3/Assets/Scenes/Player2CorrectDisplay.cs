using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2CorrectDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] Player2CorrectSprites;
    public Player2 player2;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (var i = 0; i < player2.correctCount; ++i)
        {
            Player2CorrectSprites[i].GetComponent<SpriteRenderer>().enabled = true;
        }
        for (var i = player2.correctCount; i < Player2CorrectSprites.Length; ++i)
        {
            Player2CorrectSprites[i].GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
