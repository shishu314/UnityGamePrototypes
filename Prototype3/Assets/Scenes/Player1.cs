using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player1 : MonoBehaviour
{
    private Rigidbody2D body;
    public float movementSpeed;
    private bool onGround = false;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        HandleMovement(horizontal);
        if (Input.GetKeyDown(KeyCode.W))
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
        if (collidedObjectPosition.y < gameObjPosition.y)
        {
            onGround = true;
        }
    }

    private void Jump()
    {
        if (onGround)
        {
            body.AddForce(new Vector2(0, body.mass * 7.5f), ForceMode2D.Impulse);
            onGround = false;
        }
    }
}