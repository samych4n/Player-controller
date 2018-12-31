using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackHeavyAir : PlayerStateDefault
{
    public PlayerAttackHeavyAir(PlayerStateMachine playerStateMachine) : base(playerStateMachine) { }

    public override void OnEnter()
    {
        base.OnEnter();
        animator.SetTrigger("AirHeavyAttack");
    }

    public override void OnExit()
    {
        base.OnExit();
        animator.ResetTrigger("AirHeavyAttack");
    }
    public override void Update(IInput input, float deltaTime)
    {
        if (groundCheck.IsInCollision) MyStateMachine.ChangeState(MyStateMachine.PlayerGround);
        HandleInputs(input);
    }

    public override void FixedUpdate(IInput input, float deltaTime)
    {
        playerMovement.Move(Vector2.right * input.Horizontal/2 * deltaTime);
    }

    public override void HandleInputs(IInput input)
    {

    }

    public void StartAttack()
    {
    }

    public void EndAttack()
    {
        Debug.Log("aqui 1");
        if (isThisStateActive)
        {
            Debug.Log("aqui 2");
            if (groundCheck.IsInCollision) MyStateMachine.ChangeState(MyStateMachine.PlayerGround);
            else MyStateMachine.ChangeState(MyStateMachine.PlayerAir);
        }
    }
}
