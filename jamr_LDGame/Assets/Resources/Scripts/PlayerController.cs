using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //maximum amount the player can move from origin
    private float MAX_MOVEMENT = 10f;
    public float speed = 1f;
    public float maxSpeed = 9f;
    private Vector2 screenCenter;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        screenCenter = GetScreenCenter();

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    Vector2 GetScreenCenter()
    {
        float screenHeight = Screen.height;
        float screenWidth = Screen.width;

        return new Vector2(screenWidth / 2, screenHeight / 2);
    }

    void HandleMovement()
    {
        Vector3 mousePos = GetRelativeMousePosition().normalized;

        rb.AddRelativeForce(mousePos * speed, ForceMode.Acceleration);

        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        }
    }

    /*
     * Returns the mouse position relative to the center of the screen (0, 0).
     */
    Vector3 GetRelativeMousePosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        return new Vector3(mousePosition.x - screenCenter.x, mousePosition.y - screenCenter.y);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("dead");
    }


}
