﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Ball ball;
    public Paddle paddle;

    public static Vector2 bottomLeft;
    public static Vector2 topRight;
    // Start is called before the first frame update
    void Start()
    {
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        Instantiate(ball);
        Paddle Paddle1 = Instantiate(paddle);
        Paddle Paddle2 = Instantiate(paddle);
        Paddle1.Init(true);
        Paddle2.Init(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
