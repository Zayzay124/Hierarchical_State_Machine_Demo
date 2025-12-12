using UnityEngine;

public class Phase2State : State
{
    private int Phase2Health = 10;

    public PatrolState patrolState;


    public Phase2State()
    {
        IsRootState = true;
    }

    public override void Enter()
    {
        Debug.Log("Entered Phase 2");
        patrolState.AddBehavior("Crossbeam");
        InitializeSubState();
    }

    public override void Exit() { }

    public override void Process()
    {
        if (entity.CurrentHealth < 10)
        {
            SwitchState(_machine.States["PhaseChange"]);
        }
    }

    public override void FixedProcess() { }

    public override void CheckSwitchStates() { }

    public override void InitializeSubState()
    {
        SetSubState(_machine.States["Patrol"]);
    }

}
