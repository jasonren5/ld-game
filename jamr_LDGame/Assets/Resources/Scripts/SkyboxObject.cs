using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxObject : MonoBehaviour
{
    Rigidbody rb;
    Transform skyboxCamera;
    float startingScale;
    float minScale = .1f;
    float startingDistance;
    // Start is called before the first frame update
    void Start()
    {
        startingScale = transform.localScale.x;
        skyboxCamera = SkyboxCameraController.instance.gameObject.transform;
        rb = GetComponent<Rigidbody>();

        startingDistance = Vector3.Distance(transform.position, skyboxCamera.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.instance)
        {
            if (rb && GameController.instance.isAlive)
            {
                rb.velocity = new Vector3(0, 0, -1.25f);


            }

            else
            {
                rb.velocity = Vector3.zero;
            }
        }

        float distance = Vector3.Distance(transform.position, skyboxCamera.position);
        float scale = Mathf.SmoothStep(minScale, startingScale, 10 / distance);

        transform.localScale = new Vector3(scale, scale, scale);

    }
}
