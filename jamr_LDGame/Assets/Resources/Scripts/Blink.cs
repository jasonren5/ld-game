using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blink : MonoBehaviour
{
    float timeOfLastBlink;
    float interval = .5f;
    bool isVisible;
    // Start is called before the first frame update
    void Start()
    {
        isVisible = true;
        timeOfLastBlink = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        doBlink();
    }

    void doBlink()
    {
        if (isVisible)
        {
            if (Time.time > timeOfLastBlink + interval * 2)
            {
                GetComponent<Text>().enabled = false;
                timeOfLastBlink = Time.time;
                isVisible = false;
            }
        } else
        {
            if (Time.time > timeOfLastBlink + interval)
            {
                GetComponent<Text>().enabled = true;
                timeOfLastBlink = Time.time;
                isVisible = true;
            }
        }
    }
}
