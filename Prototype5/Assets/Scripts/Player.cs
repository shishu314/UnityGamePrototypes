using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int x;
    public int y;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var transform = GetComponent<Transform>();
        var newPos = transform.position;
        if (Input.GetKeyDown(KeyCode.W))
        {
            newPos.y += 1;
            if (InBounds(newPos))
            {
                transform.position = newPos;
                y += 1;
            }
        }
        else if (Input.GetKeyDown(KeyCode.S)) {
            newPos.y -= 1;
            if (InBounds(newPos))
            {
                transform.position = newPos;
                y -= 1;
            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            newPos.x -= 1;
            if (InBounds(newPos))
            {
                transform.position = newPos;
                x -= 1;
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            newPos.x += 1;
            if (InBounds(newPos))
            {
                transform.position = newPos;
                x += 1;
            }
        }
    }

    bool InBounds(Vector3 Coordinates)
    {
        return Coordinates.x >= -7.5 && Coordinates.x <= 6.5 && Coordinates.y >= -4.5 && Coordinates.y <= -0.5;
    }
}
