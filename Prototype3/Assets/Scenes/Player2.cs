using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player2 : MonoBehaviour
{
    public Referee referee;
    public LinkedList<int> keys;
    public Vector3 startingPosition;
    public float shakeTime = 0.0f;
    public bool shouldShake = false;
    public Player1 player1;
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
        if (shouldShake)
        {
            shakeTime += Time.deltaTime;
            Shake();
        }
        if (shakeTime > 0.5)
        {
            shouldShake = false;
            shakeTime = 0;
            GetComponent<Transform>().position = startingPosition;
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
                correctCount += 1;
            }
            else
            {
                correctCount = 0;
                keys.AddLast(Random.Range(0, 4));
                shouldShake = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
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
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
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
        else if (Input.GetKeyDown(KeyCode.RightArrow))
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
        if (correctCount == 4)
        {
            player1.keys.AddFirst(Random.Range(0, 4));
            correctCount = 0;
        }
        if (keys.Count == 0)
        {
            referee.player2Victory = true;
        }
    }

    void Shake()
    {
        var newPosition = startingPosition + Random.insideUnitSphere * 1.0f;
        GetComponent<Transform>().position = newPosition;
    }
}