using UnityEngine;

public class HurtboxComponent : MonoBehaviour
{
    public Entity entity;

    void OnTriggerEnter2D(Collider2D collision)
    {
        // find try method
        HitboxComponent hitboxComp = collision.gameObject.GetComponent<HitboxComponent>();
        if (hitboxComp)
        {
            entity.TakeDamage(hitboxComp.Damage);
        }
    }
}
