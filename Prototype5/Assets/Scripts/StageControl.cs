using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageControl : MonoBehaviour
{
    public Tile tile;
    private Tile[,] tiles;
    public Player player;
    public BossHPBar bossHealthBar;
    public PlayerHPBar playerHealthBar;
    public int attackX;
    public int attackY;
    // Start is called before the first frame update
    void Start()
    {
        tiles = new Tile[15,5];
        for(var i = 0; i < 15; ++i)
        {
            for (var j = 0; j < 5; ++j)
            {
                tiles[i,j] = Instantiate(tile, new Vector3(i * 1.0F - 7.5F, j * 1.0F - 4.5F, 0), Quaternion.identity);
            }
        }
        player = Instantiate(player);
        player.x = 7;
        player.y = 2;
        attackX = -1;
        attackY = -1;
    }

    void GenerateTile()
    {
        var rand = Random.Range(0, 1000);
        if (rand <= 20)
        {
            var x = Random.Range(0, 15);
            var y = Random.Range(0, 5);
            while (tiles[x, y].State != Tile.TileState.Neutral)
            {
                x = Random.Range(0, 15);
                y = Random.Range(0, 5);
            }
            if (rand < 19)
            {
                var stateRand = Random.Range(1, 4);
                switch (stateRand)
                {
                    case 1:
                        tiles[x, y].State = Tile.TileState.Water;
                        break;
                    case 2:
                        tiles[x, y].State = Tile.TileState.Lava;
                        break;
                    case 3:
                        tiles[x, y].State = Tile.TileState.Poison;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                if (attackX < 0 && attackY < 0)
                {
                    tiles[x, y].State = Tile.TileState.Attack;
                    attackX = x;
                    attackY = y;
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
            tiles[attackX, attackY].State = Tile.TileState.Neutral;
            attackX = attackY = -1;
            bossHealthBar.HP = Mathf.Clamp(bossHealthBar.HP - 100, 0, bossHealthBar.TotalHP);
        }
        if (tiles[player.x, player.y].State != Tile.TileState.Neutral)
        {
            playerHealthBar.HP = Mathf.Clamp(playerHealthBar.HP - 1, 0, playerHealthBar.TotalHP);
        }
    }
}
