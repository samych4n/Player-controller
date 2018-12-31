using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : PlayerStateDefault
{

    public PlayerJump(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        rigidbody.velocity = Vector2.up;
        rigidbody.AddForce(Vector2.up * 400);
        if (!groundCheck.IsInCollision) playerStatus.AirJump();
    }

    

    public override void Update(IInput input, float deltaTime)
    {
        if (rigidbody.velocity.y != 0)
        {
            MyStateMachine.ChangeState(MyStateMachine.PlayerAir);
        }
        else
        {
            MyStateMachine.ChangeState(MyStateMachine.PlayerGround);
        }
        HandleInputs(input);
    }
}
