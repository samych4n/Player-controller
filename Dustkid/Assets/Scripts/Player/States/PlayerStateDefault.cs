using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerStateDefault : IPlayerState
{
    public PlayerStateMachine MyStateMachine { get; private set; }
    protected PlayerMovement playerMovement;
    protected Animator animator;
    protected Rigidbody2D rigidbody;
    protected ICollisionCheck groundCheck;
    protected ICollisionCheck wallFrontCheck;
    protected ICollisionCheck wallBackCheck;
    protected ICollisionCheck roofCheck;
    protected bool isThisStateActive = false;
    protected PlayerStatus playerStatus;
    protected PlayerGravityController playerGravityController;
    protected Collider2D collider;
    protected PlayerDirection playerDirection;

    public PlayerStateDefault(PlayerStateMachine playerStateMachine)
    {
        MyStateMachine = playerStateMachine;
        playerMovement = MyStateMachine.GetComponent<PlayerMovement>();
        animator = MyStateMachine.Animator;
        rigidbody = MyStateMachine.Rigidbody;
        playerStatus = MyStateMachine.PlayerStatus;

        groundCheck = MyStateMachine.GetComponent<PlayerGroundCheck>();
        wallFrontCheck = MyStateMachine.GetComponent<PlayerWallCheckFront>();
        wallBackCheck = MyStateMachine.GetComponent<PlayerWallCheckBack>();
        roofCheck = MyStateMachine.GetComponent<PlayerRoofCheck>();
        playerDirection = MyStateMachine.GetComponent<PlayerDirection>();

        playerGravityController = MyStateMachine.GetComponent<PlayerGravityController>();
        collider = MyStateMachine.GetComponent<Collider2D>();
    }


    public virtual void FixedUpdate(IInput input, float deltaTime)
    {
    }

    public virtual void HandleInputs(IInput input)
    {
    }

    public virtual void OnEnter()
    {
        isThisStateActive = true;
    }

    public virtual void OnExit()
    {
        isThisStateActive = false;
    }

    public virtual void Update(IInput input, float deltaTime)
    {

    }

}
