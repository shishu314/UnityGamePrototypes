using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    public Sprite[] polygons;
    private int Sides { get; set; } = 4;
    private SpriteRenderer Renderer { get; set; }
    private Vector2 targetPosition;
    // Start is called before the first frame update
    void Start()
    {
        Renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(Sides > 3)
            {
                --Sides;
                Renderer.sprite = polygons[Sides];
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * 5);
    }
}
