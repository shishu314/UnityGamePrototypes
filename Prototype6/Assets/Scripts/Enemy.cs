using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float movementSpeed;
    public bool facingLeft = false;
    public Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (movementSpeed > 0)
        {
            var spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.flipX = facingLeft;
            Vector2 velocity = new Vector2(facingLeft ? -movementSpeed : movementSpeed, 0);
            body.velocity = velocity;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ArrowCollide") && collision.gameObject.transform.position.y >= transform.position.y)
        {
            facingLeft = !facingLeft;
        }

        if(collision.gameObject.CompareTag("Arrow"))
        {
            gameObject.tag = "ArrowCollide";
            movementSpeed = 0.0f;
            var body = GetComponent<Rigidbody2D>();
            body.bodyType = RigidbodyType2D.Static;
        }
    }
}
