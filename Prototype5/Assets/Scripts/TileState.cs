using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileState : MonoBehaviour
{
    public string State;
    public float StateCount;
    // Start is called before the first frame update
    void Start()
    {
        State = "Neutral";
        StateCount = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        var spriteRenderer = GetComponent<SpriteRenderer>();
        var color = Color.white;
        switch(State)
        {
            case "Water":
                color = Color.blue;
                break;
            case "Lava":
                color = Color.red;
                break;
            case "Poison":
                color = Color.green;
                break;
            default:
                break;
        }
        spriteRenderer.color = color;
        if(State != "Neutral")
        {
            StateCount += Time.deltaTime;
            if(StateCount >= 30.0f)
            {
                State = "Neutral";
                StateCount = 0.0f;
            }
        }
    }
}
