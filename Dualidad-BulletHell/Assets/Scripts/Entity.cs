using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public int life;
    public int max_life;
    public void GetDamage(int damage)
    {
        life -= damage;
        Debug.Log(life);
        if (life <= 0)
            Death();
    }

    void Death()
    {

    }
}
