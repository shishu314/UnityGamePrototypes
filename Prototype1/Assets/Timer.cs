using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public bool Player1Turn { get; set; }
    public bool GameOver { get; set; } = false;
    // Start is called before the first frame update
    void Start()
    {
        Player1Turn = UnityEngine.Random.value > 0.5;
        InvokeRepeating("ChangeTurn", 0, 10);
    }

    void ChangeTurn()
    {
        Player1Turn = !Player1Turn;
        Color32 color = Player1Turn ? new Color32(29, 188, 212, 255) : new Color32(69, 209, 21, 255);
        GetComponent<SpriteRenderer>().color = color;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
