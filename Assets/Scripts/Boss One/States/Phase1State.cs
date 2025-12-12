using UnityEngine;

public class Phase1State : State
{
    private int PhaseHealth = 20;
    public Phase1State()
    {
        IsRootState = true;
    }

    public override void Enter()
    {
        Debug.Log("Entered Phase 1 State");
        InitializeSubState();
    }

    public override void Exit() { }

    public override void Process()
    {
        //change so this so it isn't checking every frame
        //only need to check on hit
        //signal? event?
        if (entity.CurrentHealth < PhaseHealth)
        {
            SwitchState(_machine.States["PhaseChange"]);
        }
    }

    public override void FixedProcess() { }

    public override void InitializeSubState()
    {
        SetSubState(_machine.States["Patrol"]);
    }

    public override void CheckSwitchStates()
    {

    }
}