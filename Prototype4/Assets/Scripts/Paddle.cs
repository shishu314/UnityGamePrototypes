using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed;
    float height;
    public bool isRight;
    string input;
    // Start is called before the first frame update
    void Start()
    {
        height = transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis(input) * Time.deltaTime * speed;
        if(transform.position.y < GameManager.bottomLeft.y + height/2 && move < 0)
        {
            move = 0;
        }

        if (transform.position.y > GameManager.topRight.y - height / 2 && move > 0)
        {
            move = 0;
        }

        transform.Translate(move * Vector2.up);
    }

    public void Init(bool isRightPaddle)
    {
        isRight = isRightPaddle;
        Vector2 pos = Vector2.zero;
        if(isRightPaddle)
        {
            pos = new Vector2(GameManager.topRight.x - transform.localScale.x, 0);
            input = "PaddleRight";
        } else
        {
            pos = new Vector2(GameManager.bottomLeft.x + transform.localScale.x, 0);
            input = "PaddleLeft";
        }
        transform.position = pos;
        transform.name = input;
    }
}
