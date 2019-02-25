using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Referee : MonoBehaviour
{
    public Player1 player1;
    public Player2 player2;
    public bool player1Victory = false;
    public bool player2Victory = false;
    public Sprite victorySprite;
    public Sprite defeatSprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player1Victory)
        {
            player1.GetComponent<SpriteRenderer>().sprite = victorySprite;
            var rot1 = player1.GetComponent<Transform>().eulerAngles;
            rot1.z = 0;
            player1.GetComponent<Transform>().eulerAngles = rot1;
            player2.GetComponent<SpriteRenderer>().sprite = defeatSprite;
            var rot2 = player2.GetComponent<Transform>().eulerAngles;
            rot2.z = 0;
            player2.GetComponent<Transform>().eulerAngles = rot2;
        }
        else if(player2Victory)
        {
            player1.GetComponent<SpriteRenderer>().sprite = defeatSprite;
            var rot1 = player1.GetComponent<Transform>().eulerAngles;
            rot1.z = 0;
            player1.GetComponent<Transform>().eulerAngles = rot1;
            player2.GetComponent<SpriteRenderer>().sprite = victorySprite;
            var rot2 = player2.GetComponent<Transform>().eulerAngles;
            rot2.z = 0;
            player2.GetComponent<Transform>().eulerAngles = rot2;
        }
        if(player1Victory || player2Victory)
        {
            player1.correctCount = 0;
            player2.correctCount = 0;
        }
    }
}
