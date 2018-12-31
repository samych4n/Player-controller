using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AttackSystem : MonoBehaviour
{

    private Animator animator;

    [Header("Ground Weak Attack")]
    [SerializeField] Transform transformWeakAttackFront;
    [SerializeField] GameObject particleWeakAttackFront1;
    [SerializeField] GameObject particleWeakAttackFront2;

    [SerializeField] Transform transformWeakAttackDown;
    [SerializeField] GameObject particleWeakAttackDown;

    [SerializeField] Transform transformWeakAttackUp;
    [SerializeField] GameObject particleWeakAttackUp1;
    [SerializeField] GameObject particleWeakAttackUp2;

    [Header("Air Weak Attack")]
    [SerializeField] Transform transformWeakAirAttackFront;
    [SerializeField] GameObject particleWeakAirAttackFront1;
    [SerializeField] GameObject particleWeakAirAttackFront2;

    [SerializeField] Transform transformWeakAirAttackDown;
    [SerializeField] GameObject particleWeakAirAttackDown1;
    [SerializeField] GameObject particleWeakAirAttackDown2;

    [SerializeField] Transform transformWeakAirAttackUp;
    [SerializeField] GameObject particleWeakAirAttackUp1;
    [SerializeField] GameObject particleWeakAirAttackUp2;

    [Header("Heavy Attack")]
    [SerializeField] Transform transformHeavyAttackFront;
    [SerializeField] GameObject particleHeavyAttackFront;

    [SerializeField] Transform transformHeavyAttackUp;
    [SerializeField] GameObject particleHeavyAttackUp;

    [SerializeField] Transform transformHeavyAttackDown;
    [SerializeField] GameObject particleHeavyAttackDown;

    [SerializeField] Transform transformHeavyAirAttackFront;
    [SerializeField] GameObject particleHeavyAirAttackFront;

    [SerializeField] Transform transformHeavyAirAttackUp;
    [SerializeField] GameObject particleHeavyAirAttackUp;

    [SerializeField] Transform transformHeavyAirAttackDown;
    [SerializeField] GameObject particleHeavyAirAttackDown;

    private void Awake()
    {
        CreatePools();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        foreach (var smb in animator.GetBehaviours<GroundWeakAttackSmb>())
        {
            smb.attackEffectSystem = this;
        }
        foreach (var smb in animator.GetBehaviours<AirWeakAttackSmb>())
        {
            smb.attackEffectSystem = this;
        }
        foreach (var smb in animator.GetBehaviours<AirHeavyAttackSmb>())
        {
            smb.attackEffectSystem = this;
        }
        foreach (var smb in animator.GetBehaviours<GroundHeavyAttackSmb>())
        {
            smb.attackEffectSystem = this;
        }
    }

    private void CreatePools()
    {

    }

    public GameObject StartAnimation(PlayerAttackTypes playerAttackTypes)
    {
        switch (playerAttackTypes)
        {
            case PlayerAttackTypes.WEAK_FRONT1:
                return Instantiate(particleWeakAttackFront1, transformWeakAttackFront);
            case PlayerAttackTypes.WEAK_FRONT2:
                return Instantiate(particleWeakAttackFront2, transformWeakAttackFront);
            case PlayerAttackTypes.WEAK_UP1:
                return Instantiate(particleWeakAttackUp1, transformWeakAttackUp);
            case PlayerAttackTypes.WEAK_UP2:
                return Instantiate(particleWeakAttackUp2, transformWeakAttackUp);
            case PlayerAttackTypes.WEAK_DOWN:
                return Instantiate(particleWeakAttackDown, transformWeakAttackDown);

            case PlayerAttackTypes.WEAK_AIR_FRONT1:
                return Instantiate(particleWeakAirAttackFront1, transformWeakAirAttackFront);
            case PlayerAttackTypes.WEAK_AIR_FRONT2:
                return Instantiate(particleWeakAirAttackFront2, transformWeakAirAttackFront);
            case PlayerAttackTypes.WEAK_AIR_UP1:
                return Instantiate(particleWeakAirAttackUp1, transformWeakAirAttackUp);
            case PlayerAttackTypes.WEAK_AIR_UP2:
                return Instantiate(particleWeakAirAttackUp2, transformWeakAirAttackUp);
            case PlayerAttackTypes.WEAK_AIR_DOWN1:
                return Instantiate(particleWeakAirAttackDown1, transformWeakAirAttackDown);
            case PlayerAttackTypes.WEAK_AIR_DOWN2:
                return Instantiate(particleWeakAirAttackDown2, transformWeakAirAttackDown);

            case PlayerAttackTypes.HEAVY_FRONT:
                return Instantiate(particleHeavyAttackFront, transformHeavyAttackFront);
            case PlayerAttackTypes.HEAVY_UP:
                return Instantiate(particleHeavyAttackUp, transformHeavyAttackUp);
            case PlayerAttackTypes.HEAVY_DOWN:
                return Instantiate(particleHeavyAttackDown, transformHeavyAttackDown);
            case PlayerAttackTypes.HEAVY_AIR_FRONT:
                return Instantiate(particleHeavyAirAttackFront, transformHeavyAirAttackFront);
            case PlayerAttackTypes.HEAVY_AIR_UP:
                return Instantiate(particleHeavyAirAttackUp, transformHeavyAirAttackUp);
            case PlayerAttackTypes.HEAVY_AIR_DOWN:
                return Instantiate(particleHeavyAirAttackDown, transformHeavyAirAttackDown);


            default:
                break;
        }
        return null;
    }


    public void EndAnimation(GameObject particle)
    {
        Destroy(particle);
    }



}


public enum PlayerAttackTypes
{
    WEAK_FRONT1,
    WEAK_FRONT2,
    WEAK_UP1,
    WEAK_UP2,
    WEAK_DOWN,
    WEAK_AIR_FRONT1,
    WEAK_AIR_FRONT2,
    WEAK_AIR_UP1,
    WEAK_AIR_UP2,
    WEAK_AIR_DOWN1,
    WEAK_AIR_DOWN2,
    HEAVY_FRONT,
    HEAVY_UP,
    HEAVY_DOWN,
    HEAVY_AIR_FRONT,
    HEAVY_AIR_UP,
    HEAVY_AIR_DOWN
}