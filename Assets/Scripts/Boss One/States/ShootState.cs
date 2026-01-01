using System.Collections;
using UnityEngine;

public class ShootState : State
{

    public float StartupTime;
    public Projectile projectilePrefab;
    public Transform spawnPoint;

    public BirdBoss boss;

    public override void Enter()
    {
        Debug.Log("Entered Shoot State");
        animator.Play("Flying_Demon_Attack");
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
        Projectile projectile = Instantiate(projectilePrefab);
        //projectile.Init(spawnPoint.transform.position, entity.GetComponent<BirdBoss>().PlayerDirection);
        projectile.Init(spawnPoint.transform.position, boss.PlayerDirection);


    }
}