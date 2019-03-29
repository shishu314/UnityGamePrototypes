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
        spriteRenderer.flipX = playerX > crossHairX;
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
        Vector2 force = new Vector2(horizontal * movementSpeed, 0);
        body.AddForce(force);
    }
}
