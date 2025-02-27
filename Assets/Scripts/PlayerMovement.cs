using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 4.0f;
    public Rigidbody2D rb;
    [SerializeField] private Vector2 dir;
    Animator anim;
    public bool canmove;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        canmove = true;
    }

    void Update()
    {
        //Movement Logic
        if(canmove){
            dir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            dir = Vector3.Normalize(dir);
            rb.velocity = dir * speed;
            if(dir.x != 0 || dir.y != 0){
                anim.SetFloat("X", dir.x);
                anim.SetFloat("Y", dir.y);
            }
            anim.SetBool("IsMoving", dir != Vector2.zero);
        }
    }
}
