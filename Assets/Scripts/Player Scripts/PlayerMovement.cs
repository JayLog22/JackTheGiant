using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 8f, maxVelocity = 4f;

    private Rigidbody2D rb;
    private Animator anim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        MoveKeyboard();
    }

    void MoveKeyboard()
    {
        float forceX = 0;
        float velocity = Mathf.Abs(rb.velocity.x);

        float h = Input.GetAxisRaw("Horizontal");

        if (h > 0)
        {
            if (velocity < maxVelocity)
            {
                forceX = speed;
            }

            Vector3 temp = transform.localScale;
            temp.x = 1.3f;
            transform.localScale = temp;

            anim.SetBool("isWalking", true);
        }
        else if (h < 0)
        {
            if (velocity < maxVelocity)
            {
                forceX = -speed;
            }

            Vector3 temp = transform.localScale;
            temp.x = -1.3f;
            transform.localScale = temp;

            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        rb.AddForce(new Vector2(forceX, 0));
    }
}
