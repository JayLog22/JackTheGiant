using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveTouch : MonoBehaviour
{
    public float speed = 8f, maxVelocity = 4f;

    private Rigidbody2D rb;
    private Animator anim;

    private bool moveLeft, moveRight;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (moveLeft)
        {
            MoveLeft();
        }

        if (moveRight)
        {
            MoveRight();
        }
    }

    public void SetMoveLeft(bool moveLeft)
    {
        this.moveLeft = moveLeft;
        this.moveRight = !moveLeft;
    }

    public void StopMoving()
    {
        moveLeft = moveRight = false;
        anim.SetBool("isWalking", false);
    }

    void MoveLeft()
    {
        float forceX = 0;
        float velocity = Mathf.Abs(rb.velocity.x);

        if (velocity < maxVelocity)
        {
            forceX = -speed;
        }

        Vector3 temp = transform.localScale;
        temp.x = -1.3f;
        transform.localScale = temp;

        anim.SetBool("isWalking", true);

        rb.AddForce(new Vector2(forceX, 0));
    }

    void MoveRight()
    {
        float forceX = 0;
        float velocity = Mathf.Abs(rb.velocity.x);

        if (velocity < maxVelocity)
        {
            forceX = speed;
        }

        Vector3 temp = transform.localScale;
        temp.x = 1.3f;
        transform.localScale = temp;

        anim.SetBool("isWalking", true);

        rb.AddForce(new Vector2(forceX, 0));
    }
}
