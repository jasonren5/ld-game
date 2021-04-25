using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool isAlive;

    public float speed = 1f;
    public float maxSpeed = 9f;
    private Vector2 screenCenter;
    private Rigidbody rb;

    public GameObject spawnPoint;
    private float spawnPointOffset = 300f;

    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
        screenCenter = GetScreenCenter();

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSpawnpointLocation();
    }

    private void FixedUpdate()
    {
        if (isAlive)
        {
            HandleMovement();
        }
        
    }

    Vector2 GetScreenCenter()
    {
        float screenHeight = Screen.height;
        float screenWidth = Screen.width;

        return new Vector2(screenWidth / 2, screenHeight / 2);
    }

    void HandleMovement()
    {
        Vector3 mousePos = GetRelativeMousePosition();

        Debug.Log(mousePos);

        rb.AddRelativeForce(mousePos * speed, ForceMode.Acceleration);


        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
        }

        transform.rotation = Quaternion.Euler(mousePos.y * -10f, mousePos.x * 18f, 0f);
    }

    void HandleRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * 10f * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * 10f * Time.deltaTime;

        transform.localRotation = Quaternion.AngleAxis(mouseX, Vector3.right);
        transform.localRotation = Quaternion.AngleAxis(mouseY, Vector3.up);
    }

    /*
     * Returns the mouse position relative to the center of the screen (0, 0) and number of pixels.
     */
    Vector3 GetRelativeMousePosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        return new Vector3((mousePosition.x - screenCenter.x) / (Screen.width / 2), (mousePosition.y - screenCenter.y) / (Screen.height / 2), 0f);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            isAlive = false;
            Die();
        }
    }

    void Die()
    {
        Debug.Log("dead");
        GameController.instance.EndGame();

        rb.constraints = RigidbodyConstraints.None;
    }


    //should probably change it to point closer to where the player is looking?
    void UpdateSpawnpointLocation()
    {
        Vector3 mousePos = GetRelativeMousePosition();

        float xExtrapolated = transform.position.x + 1000 / GameController.instance.GetSpeed() * mousePos.x;
        float yExtrapolated = transform.position.y + 80 / GameController.instance.GetSpeed() * mousePos.y;
        spawnPoint.transform.position = new Vector3(xExtrapolated, yExtrapolated, transform.position.z + spawnPointOffset);
    }

}
