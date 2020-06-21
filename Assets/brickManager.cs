using Assets.Enums;
using Assets.Models;
using System.Collections.Generic;
using UnityEngine;

public class brickManager : MonoBehaviour
{
    public Vector2 startPos;
    public int rows;
    public int cols;
    public float spacing;

    public List<BrickModel> bricks = new List<BrickModel>();
    private List<GameObject> prefabs = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        GeneratePrefabs();
        //ResetLevel();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ResetLevel()
    {
        bricks.ForEach(x => { Destroy(x.Brick); });
        bricks.Clear();

        for (int x = 0; x < cols; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                var prefab = prefabs[Random.Range(0, prefabs.Count)];
                var spawnPos = startPos +
                    new Vector2(
                        x * (prefab.transform.localScale.x + spacing),
                        -y * (prefab.transform.localScale.y + spacing));

                var brick = Instantiate(prefab, spawnPos, Quaternion.identity);

                var model = new BrickModel
                {
                    Brick = brick,
                    Position = spawnPos,
                    BrickType = BrickType.Yellow
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
