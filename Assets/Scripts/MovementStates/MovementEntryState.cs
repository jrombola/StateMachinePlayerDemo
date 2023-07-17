using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEntryState : State
{
    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);
        State nextState;

        if (Input.GetKeyDown(KeyCode.Space))
            nextState = new MovementJumpState();
        else
            nextState = (State) new MovementWalkingState();
        stateMachine.SetNextState(nextState);
    }
}
