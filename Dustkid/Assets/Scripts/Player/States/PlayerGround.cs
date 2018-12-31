using UnityEngine;

public class PlayerGround : PlayerStateDefault
{

    GameObject CurrentGroundObject;
    Vector3 CurrentGroundObjectLastPosition;

    public PlayerGround(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        playerGravityController.RemoveGravity();
        animator.SetTrigger("Ground");
        playerStatus.ResetAirJumps();
    }

    public override void OnExit()
    {
        base.OnExit();
        playerGravityController.RestoreGravity();
        animator.ResetTrigger("Ground");
    }
    public override void Update(IInput input, float deltaTime)
    {
        if (groundCheck.IsReallyInCollision) rigidbody.velocity = Vector2.zero;
        else rigidbody.velocity = Vector2.down * 5;
        if (!groundCheck.IsInCollision) MyStateMachine.ChangeState(MyStateMachine.PlayerAir);
        HandleInputs(input);
        if(wallFrontCheck.IsInCollision) MyStateMachine.ChangeState(MyStateMachine.PlayerWall);
    }

    public override void FixedUpdate(IInput input, float deltaTime)
    {
        if (groundCheck.IsInCollision)
        {
            var direction = new Vector2(groundCheck.Normal.y, -groundCheck.Normal.x).normalized;
            playerMovement.Move(direction * input.Horizontal * deltaTime);
        }
    }

    public override void HandleInputs(IInput input)
    {
        if (input.DashButton.IsPressDown) MyStateMachine.ChangeState(MyStateMachine.PlayerGroundDash);
        else if (input.JumpButton.IsPressDown) MyStateMachine.ChangeState(MyStateMachine.PlayerJump);
        else if (input.HeavyAttackButton.IsPressDown) MyStateMachine.ChangeState(MyStateMachine.PlayerAttackHeavyGround);
        else if (input.WeakAttackButton.IsPressDown) MyStateMachine.ChangeState(MyStateMachine.PlayerAttackWeakGround);
    }
}
