using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackWeakGround : PlayerStateDefault
{
    public PlayerAttackWeakGround(PlayerStateMachine playerStateMachine) : base(playerStateMachine) { }
    bool requestNextAttack = true;
    float maxTimeBetweenAttacks = 0.15f;
    float lastTimeAttackButtonPressed;


    public override void OnEnter()
    {
        base.OnEnter();
        animator.SetTrigger("GroundWeakAttack");
        playerGravityController.RemoveGravity();
        playerStatus.ResetAirJumps();

    }

    public override void OnExit()
    {
        base.OnExit();
        playerGravityController.RestoreGravity();
        animator.ResetTrigger("GroundWeakAttack");
    }
    public override void Update(IInput input, float deltaTime)
    {
        if (groundCheck.CurrentCollisionCollider)
        {
            if (collider.IsTouching(groundCheck.CurrentCollisionCollider))
                rigidbody.velocity = Vector2.zero;
            else
                rigidbody.velocity = Vector2.down * 5;
        }
        lastTimeAttackButtonPressed += deltaTime;
        if (lastTimeAttackButtonPressed > maxTimeBetweenAttacks) requestNextAttack = false;
        if (!groundCheck.IsInCollision) MyStateMachine.ChangeState(MyStateMachine.PlayerAir);
        HandleInputs(input);
    }

    public override void FixedUpdate(IInput input, float deltaTime)
    {
        var direction = new Vector2(groundCheck.Normal.y, -groundCheck.Normal.x).normalized;
        playerMovement.Move(direction * input.Horizontal * deltaTime);
    }

    public override void HandleInputs(IInput input)
    {
        if (input.WeakAttackButton.IsPressDown) {
            requestNextAttack = true;
            lastTimeAttackButtonPressed = 0;
        }
        if (input.JumpButton.IsPressDown) MyStateMachine.ChangeState(MyStateMachine.PlayerJump);
    }

    public void StartAttack()
    {
        requestNextAttack = false;
    }

    public void EndAttack()
    {
        if (!requestNextAttack && isThisStateActive)
        {
            if (groundCheck.IsInCollision) MyStateMachine.ChangeState(MyStateMachine.PlayerGround);
            else MyStateMachine.ChangeState(MyStateMachine.PlayerAir);
        }
    }

}
