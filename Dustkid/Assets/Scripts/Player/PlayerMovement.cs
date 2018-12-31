using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 4;
    [SerializeField] float airSpeed = 2;
    Animator animator;
    PlayerDirection playerDirection;
    new Rigidbody2D rigidbody2D;
    ICollisionCheck wallCheck;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerDirection = GetComponent<PlayerDirection>();
        wallCheck = GetComponent<PlayerWallCheckFront>();
    }

    public void Move(Vector2 direction)
    {
        playerDirection.SetPlayerDirectionX(direction.x);
        rigidbody2D.transform.Translate(Mathf.Abs(direction.x) * speed, direction.y * speed, 0);
        animator.SetFloat("MoveSpeed", (Mathf.Abs(direction.x) + Mathf.Abs(direction.y)) * speed * 100);
    }

}
