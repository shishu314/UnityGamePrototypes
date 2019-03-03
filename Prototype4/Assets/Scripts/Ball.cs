using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Vector2 Direction;
    public float speed;
    float radius;
    // Start is called before the first frame update
    void Start()
    {
        Direction = Vector2.one.normalized;
        radius = transform.localScale.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Direction * speed * Time.deltaTime);

        if (transform.position.y < GameManager.bottomLeft.y + radius && Direction.y < 0)
        {
            Direction.y *= -1;
        }

        if (transform.position.y > GameManager.topRight.y - radius / 2 && Direction.y > 0)
        {
            Direction.y *= -1;
        }

        if (transform.position.x < GameManager.bottomLeft.x + radius && Direction.x < 0)
        {
            Direction.x *= -1;
        }

        if (transform.position.x > GameManager.topRight.x - radius / 2 && Direction.x > 0)
        {
            Direction.x *= -1;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Paddle")
        {
            bool isRight = other.GetComponent<Paddle>().isRight;
            if (isRight && Direction.x > 0)
            {
                Direction.x *= -1;
            }

            if (!isRight && Direction.x < 0)
            {
                Direction.x *= -1;
            }
        }
    }
}
