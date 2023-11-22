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
        if (!GameManager.instance._playerDied)
        {
            //incremento de la velocidad default
            float IncMovespeed = moveSpeed * 5;

            //vector de direccion de nuestro input
            moveInput = new Vector2(-Input.GetAxis("Horizontal"), -Input.GetAxis("Vertical")).normalized;

            //se mueve acorde a donde apunte la camara
            rb.AddForce((-Camera.main.transform.right * moveInput.x + -Camera.main.transform.forward * moveInput.y) * IncMovespeed);

            //mantiene la velocidad en los 3 ejes segun un rango
            rb.velocity = new(
                Mathf.Clamp(rb.velocity.x, -IncMovespeed, IncMovespeed),
                Mathf.Clamp(rb.velocity.y, -50, 50),
                Mathf.Clamp(rb.velocity.z, -IncMovespeed, IncMovespeed));

            //checkea si esta tocando el suelo segun un raycast
            isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.5f, LayerMask.GetMask("Ground"));

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                rb.velocity += new Vector3(0, jumpForce, 0);
            }
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }


    private void OnTriggerEnter(Collider trigger)
    {
        Bullet bullet = trigger.GetComponent<Bullet>();
        if (bullet) { GameManager.instance.ChangeHealth(-bullet.damage/2); }
    }

    public void StartCoroutineToBlack()
    {
        StartCoroutine(changeTexturetoBlack());
    }

    IEnumerator changeTexturetoBlack()
    {
        for(float i = 1; i > 0; i-= 0.01f)
        {
            Color toBlack = new Color(i, i, i);

            transform.Find("pelota").gameObject.GetComponent<Renderer>().material.SetColor("_Color", toBlack);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
