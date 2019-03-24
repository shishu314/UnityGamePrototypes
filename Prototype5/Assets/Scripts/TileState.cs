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
        Color color;
        switch(State)
        {
            case "Water":
                var blueness = Mathf.Clamp(StateCount, 0.0f, 3.0f)/3.0f;
                color = new Color(0, 0, blueness);
                break;
            case "Lava":
                var redness = Mathf.Clamp(StateCount, 0.0f, 3.0f) / 3.0f;
                color = new Color(redness, 0, 0);
                break;
            case "Poison":
                var greeness = Mathf.Clamp(StateCount, 0.0f, 3.0f) / 3.0f;
                color = new Color(0, greeness, 0);
                break;
            case "Attack":
                color = Color.black;
                break;
            default:
                color = Color.white;
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
