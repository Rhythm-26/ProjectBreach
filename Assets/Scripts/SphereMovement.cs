using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMovement : MonoBehaviour
{
    [SerializeField, Range(0f, 100f)]
    float maxSpeed = 10f;

    [SerializeField, Range(0f, 100f)]
    float maxAcceleration = 10f;

    Vector3 desiredVelocity = new Vector3(0f, 0f, 0f);
    Vector3 velocity = new Vector3(0f, 0f, 0f);

    Rigidbody body;

    bool desiredJump;

    [SerializeField, Range(0f, 10f)]
	float jumpHeight = 2f; 

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        desiredJump |= Input.GetButtonDown("Jump");

        Vector2 playerInput;
        playerInput.x = Input.GetAxis("Horizontal");
        playerInput.y = Input.GetAxis("Vertical");
        playerInput = Vector2.ClampMagnitude(playerInput, 1f);
        desiredVelocity = new Vector3(playerInput.x, 0f, playerInput.y) * maxSpeed; 
    }

    void FixedUpdate() {
        velocity = body.velocity;
        float maxSpeedChange = maxAcceleration * Time.deltaTime;
        velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);
        velocity.z = Mathf.MoveTowards(velocity.z, desiredVelocity.z, maxSpeedChange);
        
        if (desiredJump) {
            desiredJump = false;
            Jump();
        }

        body.velocity = velocity;
    }

    void Jump() {
        velocity.y += Mathf.Sqrt(-2f * Physics.gravity.y * jumpHeight);
    }
}
