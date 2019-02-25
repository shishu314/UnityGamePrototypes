using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player1 : MonoBehaviour
{
    public Referee referee;
    public LinkedList<int> keys;
    public Vector3 startingPosition;
    public Player2 player2;
    public float shakeTime = 0.0f;
    public bool shouldShake = false;
    public int correctCount = 0;
    void Start()
    {
        startingPosition = GetComponent<Transform>().position;
    }
    
    void Update()
    {
        if (!referee.player1Victory && !referee.player2Victory)
        {
            OrientArrow();
            KeyCapture();
        }
        if(shouldShake)
        {
            shakeTime += Time.deltaTime;
            Shake();
        }
        if(shakeTime > 0.5)
        {
            shouldShake = false;
            shakeTime = 0;
            GetComponent<Transform>().position = startingPosition;
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
                correctCount += 1;
            } else
            {
                correctCount = 0;
                keys.AddLast(Random.Range(0, 4));
                shouldShake = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (first == 2)
            {
                keys.RemoveFirst();
                correctCount += 1;
            }
            else
            {
                correctCount = 0;
                keys.AddLast(Random.Range(0, 4));
                shouldShake = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (first == 1)
            {
                keys.RemoveFirst();
                correctCount += 1;
            }
            else
            {
                correctCount = 0;
                keys.AddLast(Random.Range(0, 4));
                shouldShake = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (first == 3)
            {
                keys.RemoveFirst();
                correctCount += 1;
            }
            else
            {
                correctCount = 0;
                keys.AddLast(Random.Range(0, 4));
                shouldShake = true;
            }
        }
        if(correctCount == 4)
        {
            player2.keys.AddFirst(Random.Range(0, 4));
            correctCount = 0;
        }
        if(keys.Count == 0)
        {
            referee.player1Victory = true;
        }
    }

    void Shake()
    {
        var newPosition = startingPosition + Random.insideUnitSphere * 1.0f;
        GetComponent<Transform>().position = newPosition;
    }
}