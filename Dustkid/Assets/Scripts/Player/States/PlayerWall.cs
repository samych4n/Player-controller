
using UnityEngine;

public class PlayerWall : PlayerStateDefault
{
    public PlayerWall(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        playerGravityController.RemoveGravity();
        rigidbody.velocity = Vector2.zero;
        animator.SetTrigger("Wall");
    }
    public override void OnExit()
    {
        base.OnExit();
        playerGravityController.RestoreGravity();
        animator.ResetTrigger("Wall");
    }

    public override void Update(IInput input, float deltaTime)
    {
        base.Update(input, deltaTime);
        if (!wallFrontCheck.IsInCollision)
        {
            if (groundCheck.IsInCollision) MyStateMachine.ChangeState(MyStateMachine.PlayerGround);
            else MyStateMachine.ChangeState(MyStateMachine.PlayerAir);
        }else
        if (Mathf.RoundToInt(input.Horizontal) == playerDirection.CurrentDirectionX * -1)
        {
            playerMovement.Move(Vector2.right * input.Horizontal * 0.15f / 4);
            if (groundCheck.IsInCollision) MyStateMachine.ChangeState(MyStateMachine.PlayerGround);
            else MyStateMachine.ChangeState(MyStateMachine.PlayerAir);
        }
        else
        {
            HandleInputs(input);
        }
    }

    public override void HandleInputs(IInput input)
    {
        if (input.DashButton.IsPressDown) MyStateMachine.ChangeState(MyStateMachine.PlayerWallDash);
        

    }

    public override void FixedUpdate(IInput input, float deltaTime)
    {
        base.FixedUpdate(input, deltaTime);
        if (wallFrontCheck.IsInCollision && input.Vertical > 0)
        {
            var direction = new Vector2(wallFrontCheck.Normal.y, -wallFrontCheck.Normal.x).normalized;
            playerMovement.Move(direction * input.Vertical * playerDirection.CurrentDirectionX * deltaTime);
        }
        else
        {
            playerMovement.Move(Vector2.zero);
        }
      
    }
    
}
