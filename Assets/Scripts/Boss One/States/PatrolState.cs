using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : State
{
    private float speed = 5.0f;
    private List<Vector2> points = new List<Vector2>();
    private int destination = 1; //have this calulated to be the middle later


    private List<string> stateKeys = new List<string> { "Shoot", "Dive" };
    private int stateKeyIndex = 0;

    public float timeout;
    public GameObject pointsObject; // at some point maybe nav mesh this or have something more dynamic

    public override void Enter()
    {
        if (points.Count < 1)
        {
            foreach (Transform point in pointsObject.GetComponentsInChildren<Transform>())
            {
                Vector2 nextPoint = (Vector2)point.position;
                points.Add(nextPoint);
            }
            points.RemoveAt(0); //HACK: figure out why getCompsInCh gets itself
        }
        StartCoroutine(ChangeBehavior());

    }

    public override void Exit() { }

    public override void Process() { }

    public override void FixedProcess()
    {
        entity.transform.position = Vector2.MoveTowards(entity.transform.position, points[destination], speed * Time.deltaTime);
        NextPoint();
    }

    public override void InitializeSubState() { }

    public override void CheckSwitchStates() { }

    public IEnumerator ChangeBehavior()
    {
        yield return new WaitForSeconds(timeout);

        //pick state according to list index
        SwitchState(_machine.States[stateKeys[stateKeyIndex]]);
        stateKeyIndex++;

        //reshuffle list once every action has been done once
        if (stateKeyIndex == stateKeys.Count)
        {
            IListExtensions.Shuffle(stateKeys);
            stateKeyIndex = 0;
            Debug.Log("shuffled");
        }
    }

    public void NextPoint()
    {
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

    public void AddBehavior(string stateName)
    {
        stateKeys.Add(stateName);
        foreach (string str in stateKeys)
        {
            Debug.Log(str);
        }
    }

}

public static class IListExtensions
{
    /// <summary>
    /// Shuffles the element order of the specified list.
    /// </summary>
    public static void Shuffle<T>(this IList<T> ts)
    {
        var count = ts.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i)
        {
            var r = UnityEngine.Random.Range(i, count);
            var tmp = ts[i];
            ts[i] = ts[r];
            ts[r] = tmp;
        }
    }
}