using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackHeavyGround : PlayerStateDefault
{
    public PlayerAttackHeavyGround(PlayerStateMachine playerStateMachine) : base(playerStateMachine) { }

    public override void OnEnter()
    {
        base.OnEnter();
        animator.SetTrigger("GroundHeavyAttack");
        playerGravityController.RemoveGravity();
        playerStatus.ResetAirJumps();

    }

    public override void OnExit()
    {
        base.OnExit();
        playerGravityController.RestoreGravity();
        animator.ResetTrigger("GroundHeavyAttack");
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
        if (!groundCheck.IsInCollision) MyStateMachine.ChangeState(MyStateMachine.PlayerAir);
        HandleInputs(input);
    }

    public override void FixedUpdate(IInput input, float deltaTime)
    {
        var direction = new Vector2(groundCheck.Normal.y, -groundCheck.Normal.x).normalized;
        playerMovement.Move(direction * input.Horizontal/2 * deltaTime);
    }

    public override void HandleInputs(IInput input)
    {

    }

    public void StartAttack()
    {
        
    }

    public void EndAttack()
    {
        if (isThisStateActive)
        {
            Debug.Log("aqui");
            if (groundCheck.IsInCollision) MyStateMachine.ChangeState(MyStateMachine.PlayerGround);
            else MyStateMachine.ChangeState(MyStateMachine.PlayerAir);
        }
    }

}
