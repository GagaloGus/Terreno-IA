using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine; 

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    Vector2 moveInput;

    public float moveSpeed, jumpForce;
    public bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = new Vector2(-Input.GetAxis("Horizontal"), -Input.GetAxis("Vertical"));
        moveInput.Normalize();

        rb.AddForce((-Camera.main.transform.right * moveInput.x + -Camera.main.transform.forward * moveInput.y) * moveSpeed);

        rb.velocity = new(
            Mathf.Clamp(rb.velocity.x, -moveSpeed, moveSpeed),
            Mathf.Clamp(rb.velocity.y, -30, 30),
            Mathf.Clamp(rb.velocity.z, -moveSpeed, moveSpeed));


        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.5f, LayerMask.GetMask("Ground"));

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity += new Vector3(0, jumpForce, 0);
        }

        if (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt))
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

    }
}
