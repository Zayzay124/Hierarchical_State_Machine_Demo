using System.Collections;
using UnityEngine;

public class Crossbeam : MonoBehaviour
{
    private Vector2 direction;

    public float timeTilDestroy;

    public void Init(Vector2 spawnPoint, Vector2 direction)
    {
        this.transform.position = (Vector2)spawnPoint;
        this.direction = direction.normalized;
    }

    void Start()
    {
        StartCoroutine(Pulse());
        Destroy(this.gameObject, timeTilDestroy);
    }

    void FixedUpdate()
    {
        transform.Rotate(0, 0, 1, Space.Self);
    }

    public IEnumerator Pulse() //use GetComponents maybe
    {
        yield return new WaitForSeconds(1);

        foreach (SpriteRenderer beam in GetComponentsInChildren<SpriteRenderer>())
        {
            beam.enabled = !beam.enabled;
            //beam.GetComponent<SpriteRenderer>().enabled = !beam.GetComponent<SpriteRenderer>().enabled;
        }

        foreach (HitboxComponent beam in GetComponentsInChildren<HitboxComponent>())
        {
            beam.enabled = !beam.enabled;
            //beam.GetComponent<SpriteRenderer>().enabled = !beam.GetComponent<SpriteRenderer>().enabled;
        }

        StartCoroutine(Pulse());

        //turn off visibility
        //activate hitboxes
        //Loop through boxes?

    }

}
