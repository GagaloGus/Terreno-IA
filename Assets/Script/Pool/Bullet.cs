using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float maxTime = 2;
    float speed;
    Vector3 direction;
    Rigidbody rb;
    float currentTime;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        rb.velocity = direction * speed;

        currentTime += Time.deltaTime;
        if(currentTime > maxTime)
        {
            gameObject.SetActive(false);
            currentTime = 0;
        }
    }

    public Vector3 _direction
    {
        get { return direction; }
        set { direction = value; }
    }

    public float _speed
    {
        get { return speed; }
        set { speed = value; }
    }
}
