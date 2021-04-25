using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxCameraController : MonoBehaviour
{
    Camera mainCamera;
    Vector3 startingPosition;
    float interval = 2000f;

    public static SkyboxCameraController instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        startingPosition = this.transform.position;
        interval = 200f;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateRotation();
    }

    void UpdatePosition()
    {
        transform.position = startingPosition + mainCamera.transform.position / interval;
    }

    void UpdateRotation()
    {
        transform.rotation = mainCamera.transform.rotation;
    }
}
