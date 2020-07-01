using Assets.Models;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour
{
    public Vector2 startPos;
    public int rows;
    public int cols;
    public float spacing;

    public List<BrickModel> bricks = new List<BrickModel>();

    private int level = 1;
    private List<GameObject> prefabs = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        GeneratePrefabs();
        ResetLevel();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ResetLevel()
    {
        bricks.ForEach(x => { Destroy(x.Brick); });
        bricks.Clear();
        RandomLevel();
        //GenerateLevel();
    }

    //private void GenerateLevel()
    //{
    //    var level = Levels.LevelOne;

    //    for (int x = 0; x < level.Length; x++)
    //    {
    //        for (int y = 0; y < level[x].Length; y++)
    //        {
    //            var prefab = prefabs.First(p => p.GetComponent<Brick>().BrickType == level[x][y]);
    //            var prefabBrick = prefab.GetComponent<Brick>();

    //            var spawnPos = startPos +
    //                new Vector2(
    //                    x * (prefab.transform.localScale.x + spacing),
    //                    -y * (prefab.transform.localScale.y + spacing));

    //            var brick = Instantiate(prefab, spawnPos, Quaternion.identity);

    //            var model = new BrickModel
    //            {
    //                Brick = brick,
    //                Position = spawnPos,
    //                BrickType = prefabBrick.BrickType
    //            };
    //            bricks.Add(model);
    //        }
    //    }
    //}

    private void RandomLevel()
    {
        for (int x = 0; x < cols; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                var prefab = prefabs[Random.Range(0, prefabs.Count)];
                var prefabBrick = prefab.GetComponent<Brick>();

                print($"Local Scale - x: {prefab.transform.localScale.x}");

                var spawnPos = startPos +
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
