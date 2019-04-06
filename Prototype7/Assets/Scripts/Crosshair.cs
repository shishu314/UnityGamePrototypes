using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public Player player;
    public Arrow arrow;
    public int arrowCount;
    public float arrowForce;
    public float timeHeld = 0.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var screenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z)
        {
            z = 10.0f //distance of the plane from the camera
        };
        transform.position = Camera.main.ScreenToWorldPoint(screenPoint);

        if (Input.GetMouseButton(0))
        {
            timeHeld += Time.deltaTime;
            timeHeld = Mathf.Clamp(timeHeld, 0, 4.0f);
        }

        if (Input.GetMouseButtonUp(0))
        {
            SpawnArrow();
            timeHeld = 0.0f;
        }
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
        var currentArrow = Instantiate(arrow, arrowPosition, Quaternion.identity);
        currentArrow.transform.Rotate(new Vector3(0, 0, -63f + angle * Mathf.Rad2Deg), Space.Self);
        currentArrow.angle = angle;
        var arrowBody = currentArrow.GetComponent<Rigidbody2D>();
        var force = arrowForce + timeHeld;
        arrowBody.AddForce(new Vector3(Mathf.Cos(angle)* force, Mathf.Sin(angle) * force, 0));
    }
}
