using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    public Sprite[] polygons;
    public int Sides { get; set; } = 4;
    private SpriteRenderer Renderer { get; set; }
    private Vector2 targetPosition;
    private Vector2 LastPosition { get; set; }
    private Vector2 LastVelocity { get; set; }
    private float LastAngularVelocity { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        Renderer = GetComponent<SpriteRenderer>();
        Renderer.sprite = polygons[Sides];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(Sides > 3 & Sides < 9)
            {
                --Sides;
                Renderer.sprite = polygons[Sides];
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * 5);
        LastPosition = transform.position;
        LastVelocity = GetComponent<Rigidbody2D>().velocity;
        LastAngularVelocity = GetComponent<Rigidbody2D>().angularVelocity;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        var CollidedObject = collision.gameObject;
        if(CollidedObject.name == "GainSide(Clone)")
        {
            GetComponent<Rigidbody2D>().velocity = LastVelocity;
            GetComponent<Rigidbody2D>().angularVelocity = LastAngularVelocity;
            transform.position = LastPosition;
            ++Sides;
            Renderer.sprite = polygons[Sides];
            Destroy(collision.gameObject);
        }
        if (CollidedObject.name == "LoseSide(Clone)")
        {
            GetComponent<Rigidbody2D>().velocity = LastVelocity;
            GetComponent<Rigidbody2D>().angularVelocity = LastAngularVelocity;
            transform.position = LastPosition;
            --Sides;
            Renderer.sprite = polygons[Sides];
            Destroy(collision.gameObject);
        }
    }
}
