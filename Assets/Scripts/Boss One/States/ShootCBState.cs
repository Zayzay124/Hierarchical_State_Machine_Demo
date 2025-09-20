using System.Collections;
using UnityEngine;

public class ShootCBState : State
{

    public float StartupTime;
    public CrossbeamSpawner CBSpawnerPrefab;
    public Transform spawnPoint;

    public override void Enter()
    {
        Debug.Log("Entered CB State");
        //start attack animation
        StartCoroutine(AttackCountDown());
    }

    public override void Exit() { }

    public override void Process() { }

    public override void FixedProcess() { }

    public override void InitializeSubState() { }

    public override void CheckSwitchStates() { }

    public IEnumerator AttackCountDown()
    {
        yield return new WaitForSeconds(StartupTime);

        Shoot();
        SwitchState(_machine.States["Patrol"]);
    }

    public void Shoot()
    {
        CrossbeamSpawner cbSpawner = Instantiate(CBSpawnerPrefab);
        cbSpawner.Init(spawnPoint.transform.position, entity.GetComponent<BirdBoss>().PlayerDirection);
    }
}