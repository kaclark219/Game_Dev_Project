using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 4.0f;
    private Rigidbody2D rb;
    [SerializeField] private Vector2 dir;
    private float speed = 4.0f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Movement Logic
        dir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        dir = Vector3.Normalize(dir);
        rb.velocity = dir * speed;
    }
}
