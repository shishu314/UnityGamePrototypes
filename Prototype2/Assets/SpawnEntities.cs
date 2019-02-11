using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEntities : MonoBehaviour
{
    public GameObject LoseSide;
    public GameObject GainSide;
    public Player Player;
    public float spawnTime;
    private float spawnTimer = 0;
    private float reverseTimer = 0;
    public float reverseTime;
    private bool Reverse { get; set; } = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer > spawnTime)
        {
            SpawnRandom();
            spawnTimer = 0;
        }
        reverseTimer += Time.deltaTime;
        if (reverseTimer > reverseTime)
        {
            Reverse = !Reverse;
            reverseTimer = 0;
        }
    }

    public void SpawnRandom()
    {
        var rand = Random.value;
        var screenPosition = Reverse ? Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), 0, Camera.main.farClipPlane / 2)) : Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Screen.height, Camera.main.farClipPlane / 2));
        var Entity = (rand > Player.Sides / 10.0) ? GainSide : LoseSide;
        var obj = Instantiate(Entity, screenPosition, Quaternion.identity);
        if(Reverse)
        {
            obj.GetComponent<Rigidbody2D>().gravityScale *= -1;
            var transform = obj.GetComponent<Transform>();
            var yFlip = transform.localScale;
            yFlip.y *= -1;
            obj.GetComponent<Transform>().localScale = yFlip;
        }
    }
}
