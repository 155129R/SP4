using UnityEngine;

public class enemySpawning : MonoBehaviour 
{
    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;
    public int currentTotal = 0;
    public int maxTotal = 3; 

	// Use this for initialization
	void Start () 
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
	}
	
	// Update is called once per frame
    void Spawn() 
    {
        if (GameObject.Find("LevelGenerator").GetComponent<LevelGenerator>().finished == true)
        {
            int spawnPointIndex = Random.Range(0, GameObject.Find("LevelGenerator").GetComponent<LevelGenerator>().createdTiles.Count);

            if (currentTotal < maxTotal)
            {
                Instantiate(enemy, GameObject.Find("LevelGenerator").GetComponent<LevelGenerator>().createdTiles[spawnPointIndex], Quaternion.identity);
                currentTotal++;
            }
        }
	}
}
