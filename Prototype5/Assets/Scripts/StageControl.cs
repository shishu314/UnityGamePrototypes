﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageControl : MonoBehaviour
{
    public Tile tile;
    private Tile[,] tiles;
    public Player player;
    public BossHPBar bossHealthBar;
    public PlayerHPBar playerHealthBar;
    public GameObject playerAttackText;
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
        var rand = Random.Range(0, 100);
        if (rand <= 7)
        {
            var x = Random.Range(0, 15);
            var y = Random.Range(0, 5);
            tiles[x, y].StateCount = 0.0f;
            if (rand < 7 && x != attackX && y != attackY)
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
                    tiles[x, y].ChangeToSword();
                    attackX = x;
                    attackY = y;
                }
            }
        }
    }

    void CheckPlayerAttack()
    {
        if (player.x == attackX && player.y == attackY)
        {
            tiles[attackX, attackY].Neutralize();
            attackX = attackY = -1;
            bossHealthBar.HP = Mathf.Clamp(bossHealthBar.HP - player.GetAttackPower(), 0, bossHealthBar.TotalHP);
            player.steps = new HashSet<KeyValuePair<int, int>>();
        }
    }

    void CheckPlayerInHazard()
    {
        var damageTaken = false;
        if (tiles[player.x, player.y].State != Tile.TileState.Neutral && tiles[player.x, player.y].StateCount >= 2.0f)
        {
            switch(tiles[player.x, player.y].State)
            {
                case Tile.TileState.Water:
                    if(player.classChoice == PlayerClass.Class.Human || player.classChoice == PlayerClass.Class.IronGiant)
                    {
                        playerHealthBar.HP = Mathf.Clamp(playerHealthBar.HP - 1, 0, playerHealthBar.TotalHP);
                        damageTaken = true;
                    }
                    break;
                case Tile.TileState.Lava:
                    if (player.classChoice == PlayerClass.Class.Human || player.classChoice == PlayerClass.Class.IronGiant)
                    {
                        playerHealthBar.HP = Mathf.Clamp(playerHealthBar.HP - 1, 0, playerHealthBar.TotalHP);
                        damageTaken = true;
                    }
                    break;
                case Tile.TileState.Poison:
                    if (player.classChoice == PlayerClass.Class.Human || player.classChoice == PlayerClass.Class.Undead)
                    {
                        playerHealthBar.HP = Mathf.Clamp(playerHealthBar.HP - 1, 0, playerHealthBar.TotalHP);
                        damageTaken = true;
                    }
                    break;
                default:
                    break;
            }
        }
        if (damageTaken && attackX >= 0 && attackY >= 0)
        {
            tiles[attackX, attackY].Neutralize();
            attackX = attackY = -1;
            player.steps = new HashSet<KeyValuePair<int, int>>();
        }
    }

    void CheckGameOver()
    {
        if (bossHealthBar.HP == 0)
            SceneManager.LoadScene("Win", LoadSceneMode.Single);
        if (playerHealthBar.HP == 0)
            SceneManager.LoadScene("Lose", LoadSceneMode.Single);
    }

    void SetAttackPower()
    {
        var TextMesh = playerAttackText.GetComponent<TextMesh>();
        if (attackX >= 0 && attackY >= 0)
        {
            player.steps.Add(new KeyValuePair<int, int>(player.x, player.y));
            TextMesh.text = player.GetAttackPower().ToString();
        } else
        {
            TextMesh.text = "0";
        }
    }

    // Update is called once per frame
    void Update()
    {
        GenerateTile();
        SetAttackPower();
        CheckPlayerAttack();
        CheckPlayerInHazard();
        CheckGameOver();
    }
}
