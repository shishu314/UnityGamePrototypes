using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Crosshair crosshair;
    public float movementSpeed;
    public float jumpPower;
    private Rigidbody2D body;
    private bool onGround;
    public bool facingLeft;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var crossHairX = crosshair.transform.position.x;
        var playerX = transform.position.x;
        var spriteRenderer = GetComponent<SpriteRenderer>();
        facingLeft = playerX > crossHairX;
        spriteRenderer.flipX = facingLeft;
        float horizontal = Input.GetAxis("Horizontal");
        HandleMovement(horizontal);
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (onGround)
            {
                body.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                onGround = false;
            }
        }
    }

    private void HandleMovement(float horizontal)
    {
        Vector2 velocity = new Vector2(horizontal * movementSpeed, body.velocity.y);
        body.velocity = velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(transform.position.y > collision.transform.position.y)
        {
            onGround = true;
        }
    }
}
