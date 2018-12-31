using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackWeakAir : PlayerStateDefault
{
    public PlayerAttackWeakAir(PlayerStateMachine playerStateMachine) : base(playerStateMachine) { }
    bool requestNextAttack = true;
    float maxTimeBetweenAttacks = 0.15f;
    float lastTimeAttackButtonPressed;


    public override void OnEnter()
    {
        base.OnEnter();
        animator.SetTrigger("AirWeakAttack");
    }

    public override void OnExit()
    {
        base.OnExit();
        animator.ResetTrigger("AirWeakAttack");
    }
    public override void Update(IInput input, float deltaTime)
    {
        lastTimeAttackButtonPressed += deltaTime;
        if (lastTimeAttackButtonPressed > maxTimeBetweenAttacks) requestNextAttack = false;
        if (groundCheck.IsInCollision) MyStateMachine.ChangeState(MyStateMachine.PlayerGround);
        HandleInputs(input);
    }

    public override void FixedUpdate(IInput input, float deltaTime)
    {
        playerMovement.Move(Vector2.right * input.Horizontal * deltaTime);
    }

    public override void HandleInputs(IInput input)
    {
        if (input.WeakAttackButton.IsPressDown)
        {
            requestNextAttack = true;
            lastTimeAttackButtonPressed = 0;
        }
        if (input.JumpButton.IsPressDown && playerStatus.IsAirJumpAvailable) MyStateMachine.ChangeState(MyStateMachine.PlayerJump);
        if (input.DashButton.IsPressDown && playerStatus.IsAirDashAvailable) MyStateMachine.ChangeState(MyStateMachine.PlayerAirDash);

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
