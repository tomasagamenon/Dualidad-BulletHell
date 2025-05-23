using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public int life;
    public int max_life;

    protected virtual void Start()
    {
        life = max_life;
    }

    public virtual void GetDamage(int damage)
    {
        life -= damage;
        if (life <= 0)
            Death();
    }

    protected virtual void Death()
    {

    }
}
