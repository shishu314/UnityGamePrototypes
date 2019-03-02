using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    // Prefabs
    public GameObject poisonPrefab;
    public GameObject foodPrefab;

    // Borders
    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderLeft;
    public Transform borderRight;
    // Start is called before the first frame update
    void Start()
    {
        var xLength = (int)(borderRight.position.x - borderLeft.position.x);
        var yLength = (int)(borderTop.position.y - borderBottom.position.y);
        InvokeRepeating("SpawnFood", 3, 4);
        InvokeRepeating("SpawnPoison", 3, 2);
    }

    // Spawn one piece of food
    void SpawnFood()
    {
        // x position between left & right border
        int x = (int)Random.Range(borderLeft.position.x,
                                  borderRight.position.x);

        // y position between top & bottom border
        int y = (int)Random.Range(borderBottom.position.y,
                                  borderTop.position.y);

        // Instantiate the food at (x, y)
        Instantiate(foodPrefab,
                    new Vector2(x, y),
                    Quaternion.identity); // default rotation
    }

    // Spawn one piece of poison
    void SpawnPoison()
    {
        // x position between left & right border
        int x = (int)Random.Range(borderLeft.position.x,
                                  borderRight.position.x);

        // y position between top & bottom border
        int y = (int)Random.Range(borderBottom.position.y,
                                  borderTop.position.y);

        // Instantiate the poison at (x, y)
        Instantiate(poisonPrefab,
                    new Vector2(x, y),
                    Quaternion.identity); // default rotation

    }
}
