using UnityEngine;

public class EnemyDivePart1State : State
{
    private EnemyDiveState diveState;

    public override void Enter()
    {
        diveState = (EnemyDiveState)_machine.States["Dive"];
        Debug.Log("Entered Dive Phase1");
    }

    public override void Exit() { }

    public override void Process() { }

    public override void FixedProcess()
    {
        // We never get here on the second dive
        entity.transform.position = Vector2.MoveTowards(entity.transform.position, diveState.TargetPos, diveState.diveSpeed * Time.deltaTime);
        if ((Vector2)entity.transform.position == diveState.TargetPos)
        {
            SwitchState(_machine.States["DivePart2"]);
        }
    }

    public override void InitializeSubState() { }

    public override void CheckSwitchStates() { }


}
