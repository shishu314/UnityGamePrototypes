using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float velocity;
    public float angle;
    // Start is called before the first frame update
    void Start()
    {
        var rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(velocity * Mathf.Cos(angle), velocity * Mathf.Sin(angle), 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var body = GetComponent<Rigidbody2D>();
        body.bodyType = RigidbodyType2D.Static;
    }
}
