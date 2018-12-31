using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravityController : MonoBehaviour
{
    float playerGravityScale;
    private Animator animator;
    float gravityModifier = 1;
    new Rigidbody2D rigidbody2D;
    bool isGravityActive = true;

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        playerGravityScale = rigidbody2D.gravityScale;
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        animator.SetFloat("YSpeed", rigidbody2D.velocity.y);
    }

    public void ChangeGravity(float gravityModifier)
    {
        this.gravityModifier = gravityModifier;
        if(isGravityActive)
            rigidbody2D.gravityScale = playerGravityScale * gravityModifier;
    }

    public void RemoveGravity()
    {
        rigidbody2D.gravityScale = 0;
        isGravityActive = false;
    }

    public void RestoreGravity()
    {
        isGravityActive = true;
        rigidbody2D.gravityScale = playerGravityScale * gravityModifier;
    }
}
