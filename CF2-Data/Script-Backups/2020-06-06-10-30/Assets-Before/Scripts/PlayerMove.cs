using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer sp;
    private Rigidbody2D rigid;
    public float speed;
    public float jumpSpeed;
    bool isJump;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetAxisRaw("Horizontal")>0)
        {
            rigid.velocity  = new Vector2(speed, rigid.velocity.y);
            sp.flipX = false;
            animator.SetInteger("state", 1);
        }else if ( Input.GetAxisRaw("Horizontal") < 0)
        {
            rigid.velocity  = new Vector2(-speed, rigid.velocity.y);
            sp.flipX = true;
            animator.SetInteger("state", 1);
        }
        else
        {
            rigid.velocity  = new Vector2(0, rigid.velocity.y);
            animator.SetInteger("state", 0);
        }

        if ( Input.GetKeyDown(KeyCode.Space) && !isJump)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, jumpSpeed);
            isJump = true;
            animator.SetInteger("state", 2);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isJump = false;
        animator.SetInteger("state", 0);
    }
}
