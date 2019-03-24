using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int x;
    public int y;
    public int baseAttack = 60;
    public HashSet<KeyValuePair<int, int>> steps;
    public PlayerClass.Class classChoice;
    // Start is called before the first frame update
    void Start()
    {
        steps = new HashSet<KeyValuePair<int, int>>();
        classChoice = PlayerClass.ClassChoice;
        switch(classChoice)
        {
            case PlayerClass.Class.Slime:
                baseAttack = 1;
                break;
            case PlayerClass.Class.Undead:
                baseAttack = 10;
                break;
            case PlayerClass.Class.IronGiant:
                baseAttack = 30;
                break;
            case PlayerClass.Class.Human:
                baseAttack = 60;
                break;
            default:
                baseAttack = 0;
                break;
        }
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

    public float GetAttackPower()
    {
        var multiplier = 1.0f;
        foreach(var i in steps)
        {
            multiplier *= 1.1f;
        }
        return Mathf.Round(multiplier * baseAttack);
    }
}
