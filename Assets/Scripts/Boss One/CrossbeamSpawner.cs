using System.Collections;
using UnityEngine;

public class CrossbeamSpawner : MonoBehaviour
{
    private float speed = 2.0f;
    private Vector2 direction;

    public float timeTilSpawn;
    public Crossbeam cbPrefab;


    public void Init(Vector2 spawnPoint, Vector2 direction)
    {
        this.transform.position = (Vector2)spawnPoint;
        this.direction = direction.normalized;
    }

    void Start()
    {
        StartCoroutine(SpawnCountDown());
    }

    public IEnumerator SpawnCountDown()
    {
        yield return new WaitForSeconds(timeTilSpawn);

        SpawnCrossBeam();
        Destroy(this.gameObject);
    }

    void SpawnCrossBeam()
    {
        Crossbeam cb = Instantiate(cbPrefab);
        cb.Init(this.transform.position, this.direction);

    }

    void FixedUpdate()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
