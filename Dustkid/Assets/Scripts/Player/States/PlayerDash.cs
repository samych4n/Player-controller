using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerDash : PlayerStateDefault
{
    protected Vector3 dashDirection;
    protected float timePassed = 0;

    public PlayerDash(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {

    }

    public override void OnEnter()
    {
        base.OnEnter();
        rigidbody.velocity = Vector2.zero;
        playerGravityController.RemoveGravity();
        timePassed = 0;
    }

    public override void OnExit()
    {
        base.OnExit();
        playerGravityController.RestoreGravity();
    }

    public override void Update(IInput input, float deltaTime)
    {
        if (timePassed >= playerStatus.DashTime)
        {
            if (groundCheck.IsInCollision)
                MyStateMachine.ChangeState(MyStateMachine.PlayerGround);
            else
                MyStateMachine.ChangeState(MyStateMachine.PlayerAir);
        }
        if (wallFrontCheck.IsInCollision) MyStateMachine.ChangeState(MyStateMachine.PlayerWall);
        HandleInputs(input);
    }

    public override void HandleInputs(IInput input)
    {
        if (input.WeakAttackButton.IsPressDown)
        {
            if (groundCheck.IsInCollision)
                MyStateMachine.ChangeState(MyStateMachine.PlayerAttackWeakGround);
            else
                MyStateMachine.ChangeState(MyStateMachine.PlayerAttackWeakAir);
        }
        else if (input.HeavyAttackButton.IsPressDown)
        {
            if (groundCheck.IsInCollision)
                MyStateMachine.ChangeState(MyStateMachine.PlayerAttackHeavyGround);
            else
                MyStateMachine.ChangeState(MyStateMachine.PlayerAttackHeavyAir);
        }
        if (input.JumpButton.IsPressDown && (groundCheck.IsInCollision || playerStatus.IsAirJumpAvailable)) MyStateMachine.ChangeState(MyStateMachine.PlayerJump);
    }
}
