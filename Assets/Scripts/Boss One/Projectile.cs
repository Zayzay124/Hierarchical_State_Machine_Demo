using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float speed = 5.0f;
    private Vector2 direction;

    public float timeTilDestroy;
    public Animator animator;


    public void Init(Vector2 spawnPoint, Vector2 direction)
    {
        //figure out how to rotate sprite only
        this.transform.position = (Vector2)spawnPoint;
        this.direction = direction.normalized;
    }

    void Start()
    {
        animator.Play("Fireball_Projectile");
        Destroy(this.gameObject, timeTilDestroy);
    }

    void FixedUpdate()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

}
