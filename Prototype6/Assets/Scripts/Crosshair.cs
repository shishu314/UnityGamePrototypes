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
        var playerPosition = player.transform.position;
        var crosshairPosition = transform.position;
        var dir = crosshairPosition - playerPosition;
        var angle = Mathf.Atan2(dir.y, dir.x);
        var arrowPosition = playerPosition;
        arrowPosition.x += 1.5f * Mathf.Cos(angle);
        arrowPosition.y += 1.5f * Mathf.Sin(angle);
        arrow = Instantiate(arrow, arrowPosition, Quaternion.identity);
        arrow.transform.Rotate(new Vector3(0, 0, -63f + angle * Mathf.Rad2Deg), Space.Self);
        Debug.Log(angle);
    }
}
