using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public Player player;
    public Arrow arrow;
    private List<Arrow> arrows;
    // Start is called before the first frame update
    void Start()
    {
        arrows = new List<Arrow>();
    }

    // Update is called once per frame
    void Update()
    {
        var screenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z)
        {
            z = 10.0f //distance of the plane from the camera
        };
        transform.position = Camera.main.ScreenToWorldPoint(screenPoint);

        if (Input.GetMouseButtonDown(0))
            SpawnArrow();
    }

    void SpawnArrow()
    {
        arrow = Instantiate(arrow, transform.position, Quaternion.identity);
        var rotation = arrow.transform.localRotation;
        if(player.facingLeft)
        {
            rotation.z = 1.5f;
        } else
        {
            rotation.z = -0.6f;
        }
        arrow.transform.localRotation = rotation;
    }
}
