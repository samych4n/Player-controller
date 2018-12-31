
using UnityEngine;

public class PlayerAir : PlayerStateDefault
{

    public PlayerAir(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        animator.SetTrigger("Air");
    }
    public override void OnExit()
    {
        base.OnExit();
        animator.ResetTrigger("Air");
    }

    public override void Update(IInput input, float deltaTime)
    {
        if (groundCheck.IsInCollision && rigidbody.velocity.y <= 0) MyStateMachine.ChangeState(MyStateMachine.PlayerGround);
        if (wallFrontCheck.IsInCollision) MyStateMachine.ChangeState(MyStateMachine.PlayerWall);
        HandleInputs(input);
    }
    public override void FixedUpdate(IInput input, float deltaTime)
    {
        playerMovement.Move(Vector2.right * input.Horizontal * deltaTime);
    }

    public override void HandleInputs(IInput input)
    {
        if (input.DashButton.IsPressDown && playerStatus.IsAirDashAvailable) MyStateMachine.ChangeState(MyStateMachine.PlayerAirDash);
        else if (input.WeakAttackButton.IsPressDown) MyStateMachine.ChangeState(MyStateMachine.PlayerAttackWeakAir);
        else if (input.HeavyAttackButton.IsPressDown) MyStateMachine.ChangeState(MyStateMachine.PlayerAttackHeavyAir);
        else if (input.JumpButton.IsPressDown && playerStatus.IsAirJumpAvailable) MyStateMachine.ChangeState(MyStateMachine.PlayerJump);
    }
}
