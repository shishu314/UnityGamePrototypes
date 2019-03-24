using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public TileState State;
    public float StateCount;
    public enum TileState
    {
        Neutral,
        Water,
        Lava,
        Poison,
        Attack
    }
    // Start is called before the first frame update
    void Start()
    {
        State = TileState.Neutral;
        StateCount = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        var spriteRenderer = GetComponent<SpriteRenderer>();
        Color color;
        switch(State)
        {
            case TileState.Water:
                var blueness = Mathf.Clamp(StateCount, 0.0f, 3.0f)/3.0f;
                color = new Color(0, 0, blueness);
                break;
            case TileState.Lava:
                var redness = Mathf.Clamp(StateCount, 0.0f, 3.0f) / 3.0f;
                color = new Color(redness, 0, 0);
                break;
            case TileState.Poison:
                var greeness = Mathf.Clamp(StateCount, 0.0f, 3.0f) / 3.0f;
                color = new Color(0, greeness, 0);
                break;
            case TileState.Attack:
                color = Color.black;
                break;
            default:
                color = Color.white;
                break;
        }
        spriteRenderer.color = color;
        if(State != TileState.Neutral)
        {
            StateCount += Time.deltaTime;
            if(StateCount >= 30.0f)
            {
                State = TileState.Neutral;
                StateCount = 0.0f;
            }
        }
    }
}
