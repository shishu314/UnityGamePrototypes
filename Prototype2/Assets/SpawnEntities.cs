using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEntities : MonoBehaviour
{
    public GameObject LoseSide;
    public GameObject GainSide;
    public Player Player;
    public float spawnTime;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnTime)
        {
            SpawnRandom();
            timer = 0;
        }
    }

    public void SpawnRandom()
    {
        var rand = Random.value;
        Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Screen.height, Camera.main.farClipPlane / 2));
        if(rand > Player.Sides / 20.0)
        {
            Instantiate(GainSide, screenPosition, Quaternion.identity);
        } else
        {
            Instantiate(LoseSide, screenPosition, Quaternion.identity);
        }
    }
}
