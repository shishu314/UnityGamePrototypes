using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Vector2 Direction;
    public float speed;
    float radius;
    public int numCollisionLeft;
    public GameObject textFab;
    public Sprite explosion;
    bool exploded = false;
    GameObject text;
    float explosionCount = 0;
    int numExpand = 0;
    // Start is called before the first frame update
    void Start()
    {
        Direction = Vector2.one.normalized;
        radius = transform.localScale.x / 2;
        text = Instantiate(textFab);
        text.GetComponent<MeshRenderer>().sortingLayerName = "Text";
        text.transform.Translate(new Vector2(radius/2 * -1, radius/2));
        text.GetComponent<TextMesh>().text = numCollisionLeft.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (exploded)
        {
            Direction = Vector2.zero;
            explosionCount += Time.deltaTime;
            if (explosionCount > 1.0)
            {
                explosionCount = 0.0f;
                var scale = transform.localScale;
                scale.Scale(new Vector3(2.0f, 2.0f, 1.0f));
                transform.localScale = scale;
                numExpand += 1;
            }
            if (numExpand == 4)
            {
                Destroy(gameObject);
            }
        }

        bool Collided = false;
        transform.Translate(Direction * speed * Time.deltaTime);
        if(!exploded)
            text.transform.Translate(Direction * speed * Time.deltaTime);

        if (transform.position.y < GameManager.bottomLeft.y + radius && Direction.y < 0)
        {
            Direction.y *= -1;
            Collided = true;
        }

        if (transform.position.y > GameManager.topRight.y - radius / 2 && Direction.y > 0)
        {
            Direction.y *= -1;
            Collided = true;
        }

        if (transform.position.x < GameManager.bottomLeft.x + radius && Direction.x < 0)
        {
            Direction.x *= -1;
            Collided = true;
        }

        if (transform.position.x > GameManager.topRight.x - radius / 2 && Direction.x > 0)
        {
            Direction.x *= -1;
            Collided = true;
        }

        if(Collided && !exploded)
        {
            numCollisionLeft -= 1;
            text.GetComponent<TextMesh>().text = numCollisionLeft.ToString();
            if(numCollisionLeft == 0)
            {
                GetComponent<SpriteRenderer>().sprite = explosion;
                Destroy(text);
                exploded = true;
            }
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
                numCollisionLeft -= 1;
                text.GetComponent<TextMesh>().text = numCollisionLeft.ToString();
            }

            if (!isRight && Direction.x < 0)
            {
                Direction.x *= -1;
                numCollisionLeft -= 1;
                text.GetComponent<TextMesh>().text = numCollisionLeft.ToString();
            }

            if (numCollisionLeft == 0)
            {
                GetComponent<SpriteRenderer>().sprite = explosion;
                Destroy(text);
                exploded = true;
            }

            if(exploded)
            {
                Destroy(other.gameObject);
            }
        }
    }
}
