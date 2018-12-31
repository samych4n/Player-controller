using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundWeakAttackSmb : StateMachineBehaviour
{
    [HideInInspector]
    public AttackSystem attackEffectSystem;
    [HideInInspector]
    public PlayerAttackWeakGround playerAttackWeak;
    public PlayerAttackTypes playerAttackTypes;
    private GameObject currentAttackAnimation;
    

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        currentAttackAnimation = attackEffectSystem.StartAnimation(playerAttackTypes);
        playerAttackWeak.StartAttack();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        attackEffectSystem.EndAnimation(currentAttackAnimation);
        playerAttackWeak.EndAttack();
    }
}