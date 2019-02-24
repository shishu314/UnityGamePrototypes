using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    private Rigidbody2D body;
    public float movementSpeed;
    public Sprite[] sprites;
    public bool charge;
    private bool onGround = false;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        SetCharge();
    }

    void SetCharge()
    {
        var spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = charge ? sprites[0] : sprites[1];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        HandleMovement(horizontal);
        if(Input.GetKeyDown(KeyCode.W))
        {
            Jump();
        }
    }

    private void HandleMovement(float horizontal)
    {
        Vector2 force = new Vector2(horizontal * movementSpeed, 0);
        body.AddForce(force);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        var collidedBody = col.gameObject.GetComponent<Rigidbody2D>();
        var collidedObjectPosition = col.gameObject.GetComponent<Transform>().position;
        var gameObjPosition = gameObject.GetComponent<Transform>().position;
        if (collidedBody.bodyType == RigidbodyType2D.Static && collidedObjectPosition.y < gameObjPosition.y)
        {
            onGround = true;
        }
        if(col.gameObject.tag == "ChangeCharge")
        {
            charge = !charge;
            SetCharge();
        }
    }

    private void Jump()
    {
        if(onGround)
        {
            body.AddForce(new Vector2(0, body.mass * 10), ForceMode2D.Impulse);
            onGround = false;
        }
    }
}
