using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public Player player;
    public Arrow arrow;
    private Arrow currentArrow;
    public float arrowVelocity;
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

        if (Input.GetMouseButtonDown(0) && !currentArrow)
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
        currentArrow = Instantiate(arrow, arrowPosition, Quaternion.identity);
        currentArrow.transform.Rotate(new Vector3(0, 0, -63f + angle * Mathf.Rad2Deg), Space.Self);
        currentArrow.angle = angle;
        currentArrow.velocity = arrowVelocity;
    }

    public void DestoryArrows()
    {
        if (currentArrow)
        {
            var arrowBody = currentArrow.GetComponent<Rigidbody2D>();
            if(arrowBody.bodyType == RigidbodyType2D.Static)
                Destroy(currentArrow.gameObject);
        }
    }
}
