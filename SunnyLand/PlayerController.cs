using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static SunnyLand.Constants;

public class PlayerController : MonoBehaviour
{
    private new Rigidbody2D rigidbody2D;    
    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetBool("IsJump", false);
    }

    // Update is called once per frame
    void Update()
    {
        GetPlayerInput();  //Run State는 여기 포함
        CheckStateIdle();
        CheckStateJump();
        CheckPlayerDirection();     
    }

    private void CheckStateJump()
    {
        if (rigidbody2D.velocity.y < 1 && rigidbody2D.velocity.y > -1)
        {
            animator.SetBool("IsJump", false);
        }
        else
        {
            animator.SetBool("IsJump", true);
            animator.SetTrigger("JumpTrigger");
        }
    }

    private void CheckPlayerDirection()
    {
        if (rigidbody2D.velocity.x < 0)
            GetComponent<SpriteRenderer>().flipX = true;
        else
            GetComponent<SpriteRenderer>().flipX = false;
    }

    private void CheckStateIdle()
    {
        if (rigidbody2D.velocity.x == 0 && rigidbody2D.velocity.y == 0)
            animator.SetTrigger("IdleTrigger");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Items"))
        {
            FindObjectOfType<GameManager>().IncreaseCherry();
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(FindObjectOfType<GameManager>().CherryNum >= MAX_CHERRY)
            SceneManager.LoadScene("FinishScene");
    }
    private void GetPlayerInput()
    {
        float speedX = Mathf.Abs(rigidbody2D.velocity.x);
        if (Input.GetKeyDown(KeyCode.Space) && rigidbody2D.velocity.y == 0)
        {
            rigidbody2D.AddForce(transform.up * JUMP_FORCE);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && speedX < MAX_WALK_SPEED)
        {
            rigidbody2D.AddForce(transform.right * WALK_FORCE * -1);
            animator.SetTrigger("RunTrigger");
        }
        else if (Input.GetKey(KeyCode.RightArrow) && speedX < MAX_WALK_SPEED)
        {
            rigidbody2D.AddForce(transform.right * WALK_FORCE);
            animator.SetTrigger("RunTrigger");
        }
    }
}
