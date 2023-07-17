using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEntryState : MeleeBaseState
{
    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);
        //Attack
        attackIndex = 1;
        Duration = 0.425f * 0.9f;
        animator.SetTrigger("Attack" + attackIndex);
    }

    public override void OnExit()
    {
        base.OnExit();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if(fixedtime >= Duration)
        {
            if (shouldCombo)
                stateMachine.SetNextState(new GroundComboState());
            else
                stateMachine.SetNextStateToMain();
        }
    }
}
