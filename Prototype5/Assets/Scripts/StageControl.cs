using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageControl : MonoBehaviour
{
    public TileState tile;
    private TileState[,] tiles;
    public PlayerMovement player;
    public HPBar healthBar;
    public int attackX;
    public int attackY;
    // Start is called before the first frame update
    void Start()
    {
        tiles = new TileState[15,5];
        for(var i = 0; i < 15; ++i)
        {
            for (var j = 0; j < 5; ++j)
            {
                tiles[i,j] = Instantiate(tile, new Vector3(i * 1.0F - 7.5F, j * 1.0F - 4.5F, 0), Quaternion.identity);
            }
        }
        attackX = -1;
        attackY = -1;
        player.x = 7;
        player.y = 2;
    }

    void GenerateTile()
    {
        var rand = Random.Range(0, 1000);
        if (rand <= 10)
        {
            var x = Random.Range(0, 15);
            var y = Random.Range(0, 5);
            while (tiles[x, y].State != "Neutral")
            {
                x = Random.Range(0, 15);
                y = Random.Range(0, 5);
            }
            if (rand < 6)
            {
                var stateRand = Random.Range(1, 4);
                switch (stateRand)
                {
                    case 1:
                        tiles[x, y].State = "Water";
                        break;
                    case 2:
                        tiles[x, y].State = "Lava";
                        break;
                    case 3:
                        tiles[x, y].State = "Poison";
                        break;
                    default:
                        break;
                }
            }
            else
            {
                if (attackX < 0 && attackY < 0)
                {
                    tiles[x, y].State = "Attack";
                    attackX = x;
                    attackY = y;
                    Debug.Log(attackX);
                    Debug.Log(attackY);
                    Debug.Log(player.x);
                    Debug.Log(player.y);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        GenerateTile();
        if(player.x == attackX && player.y == attackY)
        {
            tiles[attackX, attackY].State = "Neutral";
            attackX = attackY = -1;
            healthBar.HP = Mathf.Clamp(healthBar.HP - 100, 0, healthBar.TotalHP);
        }
    }
}
