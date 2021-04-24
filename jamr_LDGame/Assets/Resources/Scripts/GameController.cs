using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    float score = 0;

    float waveInterval = 2;
    float timeSinceLastWave = 0;

    //UI Outlets
    public Text scoreText;

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
        UpdateInterface();
        timeSinceLastWave = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        score += Time.deltaTime * 1000;
        UpdateInterface();

        if (CheckSpawnWave())
        {
            SpawnAsteroid();
            timeSinceLastWave = Time.time;
        }
    }
    

    void UpdateInterface()
    {
        scoreText.text = Mathf.Floor(score).ToString();
    }

    public float GetSpeed()
    {
        return Mathf.Sqrt(score / 10);
    }

    bool CheckSpawnWave()
    {
        if (Time.time > timeSinceLastWave + waveInterval)
        {
            return true;
        }
        return false;
    }

    void SpawnAsteroid()
    {
        int asteroidToSpawn = Random.Range(0, asteroids.Length);
        Instantiate(asteroids[asteroidToSpawn], spawnPoint.transform.position, new Quaternion());
    }

    public void EndGame()
    {

    }
}
