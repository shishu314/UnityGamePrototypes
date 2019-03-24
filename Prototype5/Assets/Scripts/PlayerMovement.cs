using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
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
            y += 1;
            newPos.y += 1;
        }
        else if (Input.GetKeyDown(KeyCode.S)) {
            y -= 1;
            newPos.y -= 1;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            x -= 1;
            newPos.x -= 1;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            x += 1;
            newPos.x += 1;
        }
        if (InBounds(newPos)) {
            transform.position = newPos;
        }
    }

    bool InBounds(Vector3 Coordinates)
    {
        return Coordinates.x >= -7.5 && Coordinates.x <= 6.5 && Coordinates.y >= -4.5 && Coordinates.y <= -0.5;
    }
}
