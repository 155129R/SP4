using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class LevelGenerator : NetworkBehaviour {
    [Header("Tile GameObjects")]
    public GameObject[] tiles;
    public GameObject wall;
    public GameObject Map;
    public GameObject Floors;
    public GameObject Walls;

    [Space]
    public List<Vector3> createdTiles;

    [Space]

    [Header("Tile Info")]
    public int tileAmount =  1;
    public int tileSize = 16;

    [Space]

    public float waitTime = 0.1f;

    [Space]

    public float chanceUp = 0.25f;
    public float chanceRight = 0.5f;
    public float chanceDown = 0.75f;


    [Space]

    [Header("Wall Gen Values")]
    public float minY = 999999;
    float maxY = 0;
    float minX = 999999;
    public float maxX = 0;
    public float xAmount;
    public float yAmount;
    public float extraWallX;
    public float extraWallY;

    [SyncVar(hook = "SyncSeed")]
    public int seed;

    public bool finished = false;

    public Text seedDisplay;

    //Initialization
    void Start () {


        //seed = Random.Range(0, 100);
        
    
        if (isServer)
        {
            seed = Random.Range(0, 100);

            Random.seed = seed;
            //Debug.Log(seed);
            
        }
        else
        {
            SyncSeed(seed);
            Random.seed = seed;
            Debug.Log(seed);
            if (isClient)
            {
                transform.position = Vector3.zero;
            }

        }
        StartCoroutine(GenerateLevel());
       // seedDisplay.text = seed.ToString();
      
	}  

    IEnumerator GenerateLevel()
    {
        
        for(int i = 0; i < tileAmount; i++)
        {
            float dir = Random.Range(0f, 1f); //0 - Up, 1 - right, 2 - down, 3 - left
            int tile = Random.Range(0, tiles.Length);

            CreateTile(tile);
            CallMoveGen(dir);

            yield return new WaitForSeconds(waitTime);

            if ( i == tileAmount - 1)
            {
                Finish();
            }
        }

    }

    void CallMoveGen(float randDir)
    {
        if(randDir < chanceUp)
        {
            MoveGen(0);
        }
        else if(randDir < chanceRight)
        {
            MoveGen(1);
        }
        else if(randDir < chanceDown)
        {
            MoveGen(2);
        }
        else
        {
            MoveGen(3);
        }
    }

    void MoveGen(int dir)
    {
        switch(dir)
        {
            case 0:
                transform.position = new Vector3(transform.position.x, transform.position.y + tileSize, 0);
                break;

            case 1:
                transform.position = new Vector3(transform.position.x + tileSize, transform.position.y, 0);
                break;

            case 2:
                transform.position = new Vector3(transform.position.x, transform.position.y - tileSize, 0);
                break;

            case 3:
                transform.position = new Vector3(transform.position.x - tileSize, transform.position.y, 0);
                break;
        }
    }

    void CreateTile(int tileIndex)
    {
        if (!createdTiles.Contains(transform.position))
        {
            GameObject tileObject;

            tileObject = Instantiate(tiles[tileIndex], transform.position, transform.rotation) as GameObject;
            tileObject.transform.parent = Floors.transform;
            createdTiles.Add(tileObject.transform.position);
        }
        else
            tileAmount++;
    }

    void Finish()
    {
        CreateWallValues();
        CreateWalls();
        finished = true;
    }

    void CreateWallValues()
    {
         for(int i = 0; i < createdTiles.Count; i++)
        {
            if(createdTiles[i].y < minY)
            {
                minY = createdTiles[i].y;
            }
            if(createdTiles[i].y > maxY)
            {
                maxY = createdTiles[i].y;
            }
            if (createdTiles[i].x < minX)
            {
                minX = createdTiles[i].x;
            }
            if (createdTiles[i].x > maxX)
            {
                maxX = createdTiles[i].x;
            }

            xAmount = ((maxX - minX) / tileSize) + extraWallX;
            yAmount = ((maxY - minY) / tileSize) + extraWallY;

        }
    }

    void CreateWalls()
    {
        for(int x = 0; x < xAmount; x++)
        {
            for(int y = 0; y < yAmount; y++)
            {
                if (!createdTiles.Contains(new Vector3((minX - (extraWallX * tileSize) / 2) + (x * tileSize), (minY - (extraWallY * tileSize) / 2) + (y * tileSize))))
                {
                    GameObject wallObject;
                    wallObject = Instantiate(wall, new Vector3((minX - (extraWallX * tileSize) / 2) + (x * tileSize), (minY - (extraWallY * tileSize) / 2) + (y * tileSize)), transform.rotation) as GameObject;
                    wallObject.transform.parent = Walls.transform;
                }
            }
        }
    }


    void SyncSeed(int i)
    {
        seed = i;
    }

    //public override void OnStartClient()
    //{
    //    base.OnStartClient();
    //    StartCoroutine(GenerateLevel());
    //}

    ////public override void OnStartClient()
    ////{

    ////    //base.OnStartClient();
    ////    SyncSeed(seed);
    ////    StartCoroutine(GenerateLevel());

    ////}

    //void OnServerStart()
    //{
    //    StartCoroutine(GenerateLevel());
    //    base.OnStartServer();
    //    Debug.Log("asd");
    //}

}
