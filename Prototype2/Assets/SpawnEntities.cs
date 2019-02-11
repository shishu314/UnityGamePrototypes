using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEntities : MonoBehaviour
{
    public GameObject LoseSide;
    public GameObject GainSide;
    public GameObject[] SpawnDirections;
    public Player Player;
    public float spawnTime;
    private float spawnTimer = 0;
    public float reverseTime;
    private float reverseTimer = 0;
    public float toggleTime;
    private float toggleTimer;
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
        if(reverseTimer > reverseTime - 3.0)
        {
            toggleTimer += Time.deltaTime;
            if (toggleTimer > toggleTime)
            {
                for (var i = 0; i < SpawnDirections.Length; ++i)
                {
                    ToggleDrawing(ref SpawnDirections[i]);
                }
                toggleTimer = 0;
            }
        }
        if (reverseTimer > reverseTime)
        {
            Reverse = !Reverse;
            reverseTimer = 0;
            toggleTimer = 0;
            for (var i = 0; i < SpawnDirections.Length; ++i)
            {
                FlipY(ref SpawnDirections[i]);
                SetDrawing(ref SpawnDirections[i], true);
            }
        }
    }

    private void FlipY(ref GameObject obj)
    {
        var transform = obj.GetComponent<Transform>();
        var yFlip = transform.localScale;
        yFlip.y *= -1;
        transform.localScale = yFlip;
    }

    private void SetDrawing(ref GameObject obj, bool draw)
    {
        var renderer = obj.GetComponent<SpriteRenderer>();
        renderer.enabled = draw;
    }

    private void ToggleDrawing(ref GameObject obj)
    {
        var renderer = obj.GetComponent<SpriteRenderer>();
        renderer.enabled = !renderer.enabled;
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
            FlipY(ref obj);
        }
    }
}
