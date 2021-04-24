using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    float score = 0;

    //UI Outlets
    public Text scoreText;

    


    // Start is called before the first frame update

    void Start()
    {
        UpdateInterface();
    }

    // Update is called once per frame
    void Update()
    {
        score += Time.deltaTime * 1000;
        UpdateInterface();
    }
    

    void UpdateInterface()
    {
        scoreText.text = Mathf.Floor(score).ToString();
    }
}
