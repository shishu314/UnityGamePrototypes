using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Vector3 stuckPosition;
    public int vibrateCount = 0;
    public float vibrateTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        SetRotation();
    }

    // Update is called once per frame
    void Update()
    {
        SetRotation();
        Vibrate();
    }

    void SetRotation()
    {
        var rb = GetComponent<Rigidbody2D>();
        if (rb.bodyType != RigidbodyType2D.Static)
        {
            var velocity = rb.velocity.normalized;
            var angle = Mathf.Atan2(velocity.y, velocity.x) - 1.0f;
            transform.localRotation = Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg);
        }
    }

    void Vibrate()
    {
        var body = GetComponent<Rigidbody2D>();
        if(body.bodyType == RigidbodyType2D.Static)
        {
            if(vibrateTime < 0.3f)
            {
                var pos = stuckPosition;
                if (vibrateCount % 2 == 0)
                {
                    pos.y -= 0.02f;
                } else
                {
                    pos.y += 0.02f;
                }
                transform.position = pos;
                vibrateCount += 1;
                vibrateTime += Time.deltaTime;
            } else
            {
                transform.position = stuckPosition;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("ArrowCollide") || collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Arrow"))
        {
            var body = GetComponent<Rigidbody2D>();
            body.bodyType = RigidbodyType2D.Static;
            stuckPosition = transform.position;
            SoundManager.PlaySound("arrowHit");
        }
    }
}
