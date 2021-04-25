using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public bool randomizeRotation = true;
    Rigidbody rb;
    public float speedMultiplier;
    float spawnTime;

    float scale = .1f;
    float startingScale;
    // Start is called before the first frame update
    void Start()
    {
        startingScale = transform.localScale.x;
        transform.localScale = new Vector3(.1f, .1f, .1f);
        spawnTime = Time.time;

        rb = GetComponent<Rigidbody>();

        if (randomizeRotation)
        {
            float xRotation = Random.value * 360;
            float yRotation = Random.value * 360;
            float zRotation = Random.value * 360;

            //set starting rotation
            transform.localRotation = new Quaternion(xRotation, yRotation, zRotation, 0f);

            //set rotation speed
            float rotationalForce = Random.Range(-45, 45);
            rb.AddTorque(new Vector3(xRotation, yRotation, zRotation).normalized * rotationalForce);
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(0, 0, -1 * GameController.instance.GetSpeed());

        scale = Mathf.SmoothStep(.1f, startingScale, (Time.time - spawnTime) / 3);

        transform.localScale = new Vector3(scale, scale, scale);
        //transform.localScale = Vector3.Lerp(new Vector3(.1f, .1f, .1f), Vector3.one, (Time.time - spawnTime) / 3);
    }
}
