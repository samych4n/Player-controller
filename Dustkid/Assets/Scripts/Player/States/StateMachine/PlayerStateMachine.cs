using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IInput))]
public class PlayerStateMachine : MonoBehaviour
{
    IInput input;
    Vector2 Direction;
    IPlayerState playerState;


    public Rigidbody2D Rigidbody { private set; get; }
    public PlayerStatus PlayerStatus { private set; get; }
    public Animator Animator { private set; get; }


    public PlayerGround PlayerGround { get; private set; }
    public PlayerGroundDash PlayerGroundDash { get; private set; }
    public PlayerAirDash PlayerAirDash { get; private set; }
    public PlayerWallDash PlayerWallDash { get; private set; }
    public PlayerAir PlayerAir { get; private set; }
    public PlayerJump PlayerJump { get; private set; }
    public PlayerTakingDamage PlayerTakingDamage { get; private set; }
    public PlayerAttackWeakGround PlayerAttackWeakGround { get; private set; }
    public PlayerAttackWeakAir PlayerAttackWeakAir { get; private set; }
    public PlayerAttackHeavyGround PlayerAttackHeavyGround { get; private set; }
    public PlayerAttackHeavyAir PlayerAttackHeavyAir { get; private set; }
    public PlayerWall PlayerWall { get; private set; }

    void Awake()
    {
        Animator = GetComponent<Animator>();
        PlayerStatus = GetComponent<PlayerStatus>();
        Rigidbody = GetComponent<Rigidbody2D>();

        PlayerGround = new PlayerGround(this);
        PlayerGroundDash = new PlayerGroundDash(this);
        PlayerAirDash = new PlayerAirDash(this);
        PlayerWallDash = new PlayerWallDash(this);
        PlayerAir = new PlayerAir(this);
        PlayerJump = new PlayerJump(this);
        PlayerTakingDamage = new PlayerTakingDamage(this);
        PlayerAttackWeakGround = new PlayerAttackWeakGround(this);
        PlayerAttackWeakAir = new PlayerAttackWeakAir(this);
        PlayerAttackHeavyGround = new PlayerAttackHeavyGround(this);
        PlayerAttackHeavyAir = new PlayerAttackHeavyAir(this);
        PlayerWall = new PlayerWall(this);
        
        input = GetComponent<IInput>();
    }

    private void Start()
    {
        ChangeState(PlayerGround);
        foreach (var smb in Animator.GetBehaviours<GroundWeakAttackSmb>())
        {
            smb.playerAttackWeak = PlayerAttackWeakGround;
        }
        foreach (var smb in Animator.GetBehaviours<AirWeakAttackSmb>())
        {
            smb.playerAttackWeak = PlayerAttackWeakAir;
        }
        foreach (var smb in Animator.GetBehaviours<AirHeavyAttackSmb>())
        {
            smb.playerAttackHeavy = PlayerAttackHeavyAir;
        }
        foreach (var smb in Animator.GetBehaviours<GroundHeavyAttackSmb>())
        {
            smb.playerAttackHeavy = PlayerAttackHeavyGround;
        }
    }


    public void ChangeState(IPlayerState newPlayerState)
    {
        if (playerState != null)
        {
            Debug.Log("Change state from: " + playerState.GetType() + " to: " + newPlayerState.GetType());
            playerState.OnExit();
        }
        playerState = newPlayerState;
        playerState.OnEnter();
    }


    private void Update()
    {
        SetAnimatorDirectionals(input);
        playerState.Update(input, Time.deltaTime);

    }

    private void FixedUpdate()
    {
        playerState.FixedUpdate(input, Time.fixedDeltaTime);
    }

    private void SetAnimatorDirectionals(IInput input)
    {
        if (input.Vertical > 0.8f) Animator.SetBool("DirectionUp", true);
        else Animator.SetBool("DirectionUp", false);
        if (input.Vertical < -0.8f) Animator.SetBool("DirectionDown", true);
        else Animator.SetBool("DirectionDown", false);
    }

}
