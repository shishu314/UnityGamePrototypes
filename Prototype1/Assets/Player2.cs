using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    [SerializeField]
    private Timer timer;
    private Rigidbody2D body;
    [SerializeField]
    private float movementSpeed;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal2");
        float vertical = Input.GetAxis("Vertical2");
        HandleMovement(horizontal, vertical);
    }

    private void HandleMovement(float horizontal, float vertical)
    {
        Vector2 force = new Vector2(horizontal * movementSpeed, vertical * movementSpeed);
        body.AddForce(force);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player1" && timer.Player1Turn && !timer.GameOver)
        {
            Destroy(gameObject);
            timer.GameOver = true;
        }
    }
}
