using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    float score = 0;
    float waveInterval = 10;
    float timeSinceLastWave = 0;
    int obstaclesToSpawn = 2;

    bool isAlive;

    //UI Outlets
    public Text scoreText;
    public Canvas endGameScreen;

    //obstacle Outlets
    public GameObject spawnPoint;
    public GameObject[] asteroids;

    public static GameController instance;

 

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
        UpdateInterface();
        timeSinceLastWave = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            score += Time.deltaTime * 100;
            if (CheckSpawnWave())
            {
                SpawnAsteroid();
                
                timeSinceLastWave = Time.time;
            }
        }
        
        UpdateInterface();

    }

    

    void UpdateInterface()
    {
        scoreText.text = Mathf.Floor(score).ToString();
    }

    public float GetSpeed()
    {
        if (isAlive)
        {
            return 5 + Mathf.Log(1 + (score / 100), 1.1f);
        }

        return 0;
    }

    bool CheckSpawnWave()
    {
        waveInterval = 1 + 10 / (score / 100);
        if (Time.time > timeSinceLastWave + waveInterval)
        {
            Debug.Log("waveInterval: " + waveInterval);
            return true;
        }
        return false;
    }

    void SpawnAsteroid()
    {
        int asteroidToSpawn = Random.Range(0, asteroids.Length);
        Vector3 startingPosition = spawnPoint.transform.position + RandomSpawnPoint();
        Instantiate(asteroids[asteroidToSpawn], startingPosition, new Quaternion());
    }

    public void EndGame()
    {
        isAlive = false;
        endGameScreen.gameObject.SetActive(true);
    }

    Vector3 RandomSpawnPoint()
    {
        float xBound = 25;
        float yBound = 16;

        return new Vector3(Random.Range(-xBound, xBound), Random.Range(-yBound, yBound));
    }
}
