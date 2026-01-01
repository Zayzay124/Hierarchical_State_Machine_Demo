using System.Collections;
using UnityEngine;

public class HitboxComponent : MonoBehaviour
{
    public int _damage;
    public int _knockbackForce;
    public int _stunForce;

    public int _recoveryTime;


    public int Damage { get { return _damage; } }
    public int KnockbackForce { get { return _knockbackForce; } }
    public int StunForce { get { return _stunForce; } }

    public void Activate()
    {
        enabled = true;
    }

    public void Deactivate()
    {
        enabled = false;
    }

}
