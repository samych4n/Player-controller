using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirDash : PlayerDash
{

    public PlayerAirDash(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {

    }

    public override void OnEnter()
    {
        base.OnEnter();
        MyStateMachine.Animator.SetTrigger("AirDash");
        if (!groundCheck.IsInCollision) playerStatus.AirDash();
    }

    public override void OnExit()
    {
        base.OnExit();
        animator.ResetTrigger("AirDash");
    }


    public override void FixedUpdate(IInput input, float deltaTime)
    {
        timePassed += deltaTime;
        rigidbody.transform.Translate(Vector3.right * playerStatus.DashDistance * (1 / playerStatus.DashTime) * deltaTime);
    }
}
