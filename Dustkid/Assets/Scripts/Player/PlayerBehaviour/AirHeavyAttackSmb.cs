using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirHeavyAttackSmb : StateMachineBehaviour
{
    [HideInInspector]
    public AttackSystem attackEffectSystem;
    [HideInInspector]
    public PlayerAttackHeavyAir playerAttackHeavy;
    public PlayerAttackTypes playerAttackTypes;
    private GameObject currentAttackAnimation;
    

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        currentAttackAnimation = attackEffectSystem.StartAnimation(playerAttackTypes);
        playerAttackHeavy.StartAttack();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        attackEffectSystem.EndAnimation(currentAttackAnimation);
        playerAttackHeavy.EndAttack();
    }
}