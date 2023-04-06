using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerVelocity = 10;
    public PlayerAnimationController playerAnim;
    private Rigidbody2D rigidbody2d;
    private Vector3 facingRight;
    private Vector3 facingLeft;
    bool isWalking = false;
    bool isJumping = false;

    private void Start()
    {
        rigidbody2d = transform.GetComponent < Rigidbody2D>();
        facingRight = transform.localScale;
        facingLeft = transform.localScale;
        facingLeft.x = facingLeft.x * -1;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float jumpVelocity = 10f;
            rigidbody2d.velocity = Vector2.up * jumpVelocity;
            SetIsJumping(true);
            return;
        }
        if(Input.GetAxis("Horizontal") == -1)
        {
            Debug.Log("Seta Esquerda");
            SetIsWalking(true);
            transform.localScale = facingLeft;
            transform.position -= transform.right * (Time.deltaTime * playerVelocity);
            return;
        }
        if (Input.GetAxis("Horizontal") == 1)
        {
            Debug.Log("Seta Direita");
            SetIsWalking(true);
            transform.localScale = facingRight;
            transform.position += transform.right * (Time.deltaTime * playerVelocity);
            return;
        }
        SetIsWalking(false);
        SetIsJumping(false);
    }
    private void SetIsWalking(bool value)
    {
        if (value != isWalking)
        {
            if (value)
            {
                Debug.Log("Walking");
                playerAnim.PlayAnimation("playerWalk");
            }
            else {
                Debug.Log("Idle");
                playerAnim.PlayAnimation("playerIdle");
            }
        }
        isWalking = value;
    }
    private void SetIsJumping(bool value)
    {
        if (value != isJumping)
        {
            if (value)
            {
                Debug.Log("Jumping");
                playerAnim.PlayAnimation("playerJump");
            }
            else
            {
                Debug.Log("Idle");
                playerAnim.PlayAnimation("playerIdle");
            }
        }
        isJumping = value;
    }
}
