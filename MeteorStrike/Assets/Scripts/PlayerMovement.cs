using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float speed = 2.5f;
    [SerializeField] float xMin, xMax, zMin, zMax;
    [SerializeField] private float tiltValue;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        print("PlayerController.cs] moveHorizontal: " + moveHorizontal);
        print("PlayerController.cs] moveVertical: " + moveVertical);
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;
    }

    void clampPosition()
    {
        float clampX = Mathf.Clamp(rb.position.x, xMin, xMax);
        float clampZ = Mathf.Clamp(rb.position.z, zMin, zMax);
        rb.position = new Vector3(clampX, 0.0f, clampZ);
    }

    private void FixedUpdate()
    {
        clampPosition();
            move();
        tilt();
    }
    // Update is called once per frame
    void Update()
    { }
    void tilt()
    {
        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tiltValue);
    }

}
