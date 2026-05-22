using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float HP;
    private float tilesToBuild;
    private List<GameObject> gameObjects;

    [SerializeField] private GameObject towerBlockPrefab;
    void Start()
    {
        HP = 40;
        gameObjects = new List<GameObject>();
        createTower();

    }

    
    void Update()
    {
        if((int) (HP / 10) != tilesToBuild)
        {
            int newTilesToBuild = (int) (HP / 10);
            if (newTilesToBuild < 0)
            {
                newTilesToBuild = 0;
            }
            int diff = (int)tilesToBuild - newTilesToBuild;

            Debug.Log(tilesToBuild + " " + newTilesToBuild);
            if (diff > 0) eliminateTile(diff);
            else addTile(newTilesToBuild);

        }
    }

    private void createTower()
    {
        tilesToBuild = (int) HP / 10;
        if (tilesToBuild < 0)
        {
            tilesToBuild = 0;
        }

        float startX = 0.1f;
        float startY = -3.9f;
        Vector3 blockScale = new Vector3(5, 4, 1);

        for (int i = 0; i < tilesToBuild; i++)
        {
            float posY = startY + (i * 1.67f);
            Vector3 spawnPosition = new Vector3(startX, posY, 0);

            GameObject newBlock = Instantiate(towerBlockPrefab, spawnPosition, Quaternion.identity);
            
            gameObjects.Add(newBlock);

            // Applica la scala corretta (X: 5, Y: 4, Z: 1)
            newBlock.transform.localScale = blockScale;
        }
    }

    private void eliminateTile(int tilesToEliminate)
    {
        for (int i = 0; i < tilesToEliminate; i++)
        {
            if (gameObjects.Count > 0)
            {
                int lastIndex = gameObjects.Count - 1;
                GameObject blockToDestroy = gameObjects[lastIndex];

                gameObjects.RemoveAt(lastIndex);

                Destroy(blockToDestroy);
            }
        }

        tilesToBuild = (int)(HP / 10);
        if(tilesToBuild < 0)
        {
            tilesToBuild = 0;
        }

    }

    private void addTile(int tilesToBuild) { 
        this.tilesToBuild = tilesToBuild;
        Vector3 blockScale = new Vector3(5, 4, 1);

        float startX = 0.1f;
        float startY = -3.9f;

        for(int i=gameObjects.Count - 1; i<tilesToBuild + gameObjects.Count - 1; i++)
        {
            float posY = startY + (i * 1.67f);

            Vector3 spawnPosition = new Vector3(startX, posY, 0);

            GameObject newBlock = Instantiate(towerBlockPrefab, spawnPosition, Quaternion.identity);

            newBlock.transform.localScale = blockScale;
        }

        
    }

    public void setHP(float value) { HP = value; if (HP < 0) HP = 0; }
}
