using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallDash : PlayerDash
{    
    public PlayerWallDash(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {

    }

    public override void OnEnter()
    {
        base.OnEnter();
        MyStateMachine.Animator.SetTrigger("AirDash");
        playerDirection.SetPlayerDirectionX(playerDirection.CurrentDirectionX * -1);
    }

    public override void OnExit()
    {
        base.OnExit();
        animator.ResetTrigger("AirDash");
    }


    public override void FixedUpdate(IInput input, float deltaTime)
    {
        Debug.Log("update");
        timePassed += deltaTime;
        rigidbody.transform.Translate(Vector3.right * playerStatus.DashDistance * (1 / playerStatus.DashTime) * deltaTime);
    }
}
