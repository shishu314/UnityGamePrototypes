using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SetRotation();
    }

    // Update is called once per frame
    void Update()
    {
        SetRotation();
    }

    void SetRotation()
    {
        var rb = GetComponent<Rigidbody2D>();
        var velocity = rb.velocity.normalized;
        var angle = Mathf.Atan2(velocity.y, velocity.x) - 1.0f;
        transform.localRotation = Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("ArrowCollide") || collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Arrow"))
        {
            var body = GetComponent<Rigidbody2D>();
            body.bodyType = RigidbodyType2D.Static;
        }
    }
}
