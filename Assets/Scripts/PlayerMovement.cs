using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Vector2 dir;

    private float speed = 5.0f;
    private Rigidbody2D rb;

    private bool InteractorEnabled = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        dir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        dir = Vector3.Normalize(dir);
        rb.velocity = dir * speed;
    }

    public void EnableInteractor() { InteractorEnabled = true; }

    public void DisableInteractor() { InteractorEnabled = false; }
}
