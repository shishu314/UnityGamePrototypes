using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player1 : MonoBehaviour
{
    public Referee referee;
    public LinkedList<int> keys;
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!referee.player1Victory && !referee.player2Victory)
        {
            OrientArrow();
            KeyCapture();
        }
    }

    void OrientArrow()
    {
        var transform = GetComponent<Transform>();
        var currKey = keys.First.Value;
        var rot = transform.eulerAngles;
        switch(currKey)
        {
            case 0:
                rot.z = 0;
                break;
            case 1:
                rot.z = 90;
                break;
            case 2:
                rot.z = 180;
                break;
            case 3:
                rot.z = 270;
                break;
            default:
                break;
        }
        transform.eulerAngles = rot;
    }

    void KeyCapture()
    {
        var first = keys.First.Value;
        if (Input.GetKeyDown(KeyCode.W))
        {
            if(first == 0)
            {
                keys.RemoveFirst();
            } else
            {
                keys.AddLast(Random.Range(0, 4));
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (first == 2)
            {
                keys.RemoveFirst();
            }
            else
            {
                keys.AddLast(Random.Range(0, 4));
            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (first == 1)
            {
                keys.RemoveFirst();
            }
            else
            {
                keys.AddLast(Random.Range(0, 4));
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (first == 3)
            {
                keys.RemoveFirst();
            }
            else
            {
                keys.AddLast(Random.Range(0, 4));
            }
        }
        if(keys.Count == 0)
        {
            referee.player1Victory = true;
        }
    }
}