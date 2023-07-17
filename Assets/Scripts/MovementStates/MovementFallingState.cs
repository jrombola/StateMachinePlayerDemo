using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementFallingState : MovementBaseState
{


    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);
        animator.SetBool("Walk", false);
    }

    public override void OnExit()
    {
        base.OnExit();
    }

    public override void OnFixedUpdate()
    {  
        base.OnFixedUpdate();
        if (Physics2D.OverlapBox(rig.transform.position , new Vector2(0.63f, 0.093f), 0))
        {
            animator.SetFloat("fallSpeed", 0);
            stateMachine.SetNextStateToMain();
        }
    }

    public override void OnLateUpdate()
    {
        base.OnLateUpdate();
    }

    public override void OnUpdate()
    {
        animator.SetFloat("fallSpeed", rig.velocity.y);
        base.OnUpdate();


    }
}
