using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float velocityX;
    public float velocityY;
    // Start is called before the first frame update
    void Start()
    {
        
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
