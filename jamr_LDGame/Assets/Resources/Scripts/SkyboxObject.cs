using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxObject : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb)
        {
            Debug.Log(GameController.instance.GetSpeed());
            rb.velocity = new Vector3(0, 0, -10 * GameController.instance.GetSpeed() / 200f);
        }
        
    }
}
