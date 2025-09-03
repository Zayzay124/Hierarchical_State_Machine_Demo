using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyPatrolState : State
{
    private float speed = 5.0f;
    private List<Vector2> points = new List<Vector2>();
    private float timer;
    private int destination = 1; //have this calulated to be the middle later

    public float timeout;
    public GameObject pointsObject;

    private int timesAttacked = 0;

    public override void Enter()
    {
        if (points.Count < 1)
        {
            foreach (Transform point in pointsObject.GetComponentsInChildren<Transform>())
            {
                Vector2 nextPoint = (Vector2)point.position;
                points.Add(nextPoint);
                //Debug.Log(nextPoint);
            }
            points.RemoveAt(0); //HACK: figure out why getCompsInCh gets itself
        }

    }

    public override void Exit() { }

    public override void Process()
    {

        timer += Time.deltaTime;

        if (timer > timeout)
        {
            timer = 0.0f;
            //Randomize State we go into or do one of each?
            if (timesAttacked == 0) { SwitchState(_machine.States["Shoot"]); timesAttacked++; }
            else if (timesAttacked == 1) { SwitchState(_machine.States["Dive"]); timesAttacked++; }
            else if (timesAttacked == 2) { SwitchState(_machine.States["Shoot"]); timesAttacked++; }
            else if (timesAttacked == 3) { SwitchState(_machine.States["Dive"]); timesAttacked++; }
            else if (timesAttacked == 4) { SwitchState(_machine.States["Shoot"]); timesAttacked++; }
            else if (timesAttacked == 5) { SwitchState(_machine.States["Dive"]); timesAttacked++; }
        }
    }

    public override void FixedProcess()
    {
        entity.transform.position = Vector2.MoveTowards(entity.transform.position, points[destination], speed * Time.deltaTime);
        if ((Vector2)entity.transform.position == points[destination])
        {
            destination++;
            if (destination == points.Count)
            {
                destination = 0;
                points.Reverse();
            }
        }
    }

    public override void InitializeSubState() { }

    public override void CheckSwitchStates() { }
}