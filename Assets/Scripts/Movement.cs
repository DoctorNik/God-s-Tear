using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public Joystick joystick;
    public float speed;
    public float jumpForce;
    bool isGrounded = false;
    int kJump = 0;
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (joystick.Horizontal != 0)
            Move();
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    void Move()
    {
        Vector3 dir = transform.right * joystick.Horizontal;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
    }

    public void Jump()
    {
        if (!isGrounded && (kJump > 0)) // пока ты не поднялся достаточно высоко над землёй, checkground всё ещё трогает землю и обнуляет kJump, поэтому тут ноль, а не 1
            return;
        rb.velocity = Vector2.up * jumpForce;
        kJump++;
    }

    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.1f);
        isGrounded = collider.Length > 1;
        if (isGrounded)
            kJump = 0;
    }
}
