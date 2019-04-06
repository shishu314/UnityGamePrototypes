using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Crosshair : MonoBehaviour
{
    public Player player;
    public Arrow arrow;
    public int arrowCount;
    public float arrowForce;
    public float timeHeld = 0.0f;
    public Vector3 originalScale;
    // Start is called before the first frame update
    void Start()
    {
        originalScale = transform.localScale;
        switch(SceneManager.GetActiveScene().name)
        {
            case "Level1":
                arrowCount = 1337;
                break;
            case "Level2":
                arrowCount = 10;
                break;
            case "Level3":
                arrowCount = 5;
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        var screenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z)
        {
            z = 10.0f //distance of the plane from the camera
        };
        transform.position = Camera.main.ScreenToWorldPoint(screenPoint);

        if(Input.GetMouseButtonDown(0) && arrowCount > 0)
        {
            SoundManager.PlaySound("pullBow");
        }

        if (Input.GetMouseButton(0) && arrowCount > 0)
        {
            timeHeld += Time.deltaTime;
            timeHeld = Mathf.Clamp(timeHeld, 0, 4.0f);
        }

        if (Input.GetMouseButtonUp(0) && arrowCount > 0)
        {
            SpawnArrow();
            timeHeld = 0.0f;
            arrowCount -= 1;
        }

        var scale = Mathf.Clamp(timeHeld / 4.0f + 1.0f, 1.0f, 1.5f);
        transform.localScale = new Vector3(originalScale.x / scale, originalScale.y / scale, originalScale.z);
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
        var arrowBody = currentArrow.GetComponent<Rigidbody2D>();
        var force = arrowForce + timeHeld;
        arrowBody.AddForce(new Vector3(Mathf.Cos(angle)* force, Mathf.Sin(angle) * force, 0));
    }
}
