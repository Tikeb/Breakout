﻿using Assets.Enums;
using Assets.Levels;
using Assets.Models;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BrickManager : MonoBehaviour
{
    public Vector2 startPosition;
    public int rows;
    public int cols;
    public float spacing;

    public List<BrickModel> bricks = new List<BrickModel>();
    public int remainingBricks = 0;

    private int level = 1;
    private List<GameObject> prefabs = new List<GameObject>();

    void Start()
    {
        GeneratePrefabs();
        ResetLevel();
    }

    public void ResetLevel()
    {
        bricks.ForEach(x => { Destroy(x.Brick); });
        bricks.Clear();
        remainingBricks = 0;

        if (level == 0)
            RandomLevel();
        else
            GenerateLevel(level);
    }

    public void NextLevel()
    {
        if (level > 0)
            level++;
        ResetLevel();
    }

    private void GenerateLevel(int levelToLoad)
    {
        var level = Levels.LevelOne;

        if (levelToLoad == 2)
            level = Levels.LevelTwo;

        for (int x = 0; x < level.Length; x++)
        {
            for (int y = 0; y < level[x].Length; y++)
            {
                var prefab = prefabs.First(p => p.GetComponent<Brick>().brickType == level[x][y]);
                var prefabBrick = prefab.GetComponent<Brick>();

                var spawnPos = startPosition +
                    new Vector2(
                        x * (prefab.transform.localScale.x + spacing),
                        -y * (prefab.transform.localScale.y + spacing));

                var brick = Instantiate(prefab, spawnPos, Quaternion.identity);

                var model = new BrickModel
                {
                    Brick = brick,
                    Position = spawnPos,
                    BrickType = prefabBrick.brickType
                };

                bricks.Add(model);

                if (prefabBrick.brickType != BrickType.None && prefabBrick.brickType != BrickType.Unbreakable)
                    remainingBricks++;
            }
        }
    }

    // Refactor these two methods to remove duplicate code

    private void RandomLevel()
    {
        for (int x = 0; x < cols; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                var randomNum = Random.Range(0, prefabs.Count + 1);
                var model = new BrickModel();

                var brickSpace = new Vector2(
                        x * (prefabs[0].transform.localScale.x + spacing),
                        -y * (prefabs[0].transform.localScale.y + spacing));

                var spawnPos = startPosition + brickSpace;

                if (randomNum < prefabs.Count)
                {
                    var prefab = prefabs[Random.Range(0, prefabs.Count)];
                    var prefabBrick = prefab.GetComponent<Brick>();
                    var brick = Instantiate(prefab, spawnPos, Quaternion.identity);

                    model = new BrickModel
                    {
                        Brick = brick,
                        Position = spawnPos,
                        BrickType = prefabBrick.brickType
                    };

                    if (prefabBrick.brickType != BrickType.None && prefabBrick.brickType != BrickType.Unbreakable)
                        remainingBricks++;
                }
                else
                {
                    // Add an empty space
                    model = new BrickModel
                    {
                        Brick = null,
                        Position = spawnPos,
                        BrickType = BrickType.None
                    };
                }
                bricks.Add(model);
            }
        }
    }

    private void GeneratePrefabs()
    {
        foreach (GameObject prefab in Resources.LoadAll("Prefabs/Bricks", typeof(GameObject)))
        {
            prefabs.Add(prefab);
        }
    }
}
