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
        if (mainCamera)
        {
            transform.rotation = mainCamera.transform.rotation;
        }

        else
        {
            float screenHeight = Screen.height;
            float screenWidth = Screen.width;

            Vector2 screenCenter =  new Vector2(screenWidth / 2, screenHeight / 2);

            Vector3 mousePosition = Input.mousePosition;
            Vector3 relativeMousePos = new Vector3((mousePosition.x - screenCenter.x) / (Screen.width / 2), (mousePosition.y - screenCenter.y) / (Screen.height / 2), 0f);
            transform.rotation = Quaternion.Euler(relativeMousePos.y * -10f, relativeMousePos.x * 18f, 0f);
        }
        
    }
}
