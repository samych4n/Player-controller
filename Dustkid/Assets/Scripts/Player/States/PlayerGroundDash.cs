using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundDash : PlayerDash
{
        public PlayerGroundDash(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {

    }

    public override void OnEnter()
    {
        base.OnEnter();
        animator.SetTrigger("GroundDash");
    }

    public override void OnExit()
    {
        base.OnExit();
        animator.ResetTrigger("GroundDash");
    }


    public override void FixedUpdate(IInput input, float deltaTime)
    {
        timePassed += deltaTime;
        if (groundCheck.IsInCollision)
        {
            dashDirection = new Vector2(groundCheck.Normal.y, -groundCheck.Normal.x * playerDirection.CurrentDirectionX).normalized;
        }
        if (wallFrontCheck.IsInCollision) dashDirection = Vector2.zero;

        rigidbody.transform.Translate(dashDirection * playerStatus.DashDistance * (1 / playerStatus.DashTime) * deltaTime);        
    }

}
