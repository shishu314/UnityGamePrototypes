using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Crosshair crosshair;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var crossHairX = crosshair.transform.position.x;
        var playerX = transform.position.x;
        var spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.flipX = playerX > crossHairX;
    }
}
