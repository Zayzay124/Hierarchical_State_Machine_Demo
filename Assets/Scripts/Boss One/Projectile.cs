using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float speed = 5.0f;
    private Vector2 direction;

    public float timeTilDestroy;


    public void Init(Vector2 spawnPoint, Vector2 direction)
    {
        this.transform.position = (Vector2)spawnPoint;
        this.direction = direction.normalized;
    }

    void Start()
    {
        Destroy(this.gameObject, timeTilDestroy);
    }

    void FixedUpdate()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

}
