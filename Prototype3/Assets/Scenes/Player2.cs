using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player2 : MonoBehaviour
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

    private void OrientArrow()
    {
        var transform = GetComponent<Transform>();
        var currKey = keys.First.Value;
        var rot = transform.eulerAngles;
        switch (currKey)
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

    private void KeyCapture()
    {
        var first = keys.First.Value;
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (first == 0)
            {
                keys.RemoveFirst();
            }
            else
            {
                keys.AddLast(Random.Range(0, 4));
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
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
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
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
        else if (Input.GetKeyDown(KeyCode.RightArrow))
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
        if (keys.Count == 0)
        {
            referee.player2Victory = true;
        }
    }
}