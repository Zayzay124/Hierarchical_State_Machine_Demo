using UnityEngine;

public class PhaseChange : State
{
    // boss plays animation that signifies it's changing phases
    // on enter play anim and then move to correct state

    public override void Enter()
    {
        //play anim
        ChangeState();
    }

    public override void Exit() { }

    public override void Process() { }

    public override void FixedProcess() { }

    public override void InitializeSubState() { }

    public override void CheckSwitchStates() { }

    private void ChangeState()
    {
        if (entity.CurrentHealth < 20 && entity.CurrentHealth > 10)
        {
            SwitchState(_machine.States["Phase2"]);
        }
        else if (entity.CurrentHealth < 10)
        {
            SwitchState(_machine.States["Phase3"]);
        }
    }
}
