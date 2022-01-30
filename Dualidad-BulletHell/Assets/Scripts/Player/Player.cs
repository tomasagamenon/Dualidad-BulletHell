using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    //public float speed;
    public float rotation_speed;
    public Deffensive[] defensive;
    public Offensive[] offensive;
    public Visual_Player visual;

    private void Start()
    {
        visual = GetComponent<Visual_Player>();
    }

    void Update()
    {
        float translationy = Input.GetAxis("Vertical");
        float translationx = Input.GetAxis("Horizontal");

        visual.Move(new Vector2(-translationx, translationy));

        translationy *= Time.deltaTime * (defensive[LevelSystem.main.GetLv_Defensive()].speed);
        translationx *= Time.deltaTime * (defensive[LevelSystem.main.GetLv_Defensive()].speed);

        transform.Translate(translationx, translationy, 0, Space.World);
        //Vector3 lookAtPos = new Vector3(translationx, translationy, 0);
        //if(lookAtPos.magnitude > 0)
        //{
        //    Quaternion newRotation = Quaternion.LookRotation(transform.forward, lookAtPos);
        //    transform.rotation = Quaternion.RotateTowards(transform.rotation, newRotation, Time.deltaTime * rotation_speed);
        //}
    }

    public override void GetDamage(int damage)
    {
        base.GetDamage(damage);
        var bullets = FindObjectsOfType<Bullet>();
        foreach (Bullet bullet in bullets)
            if (!bullet.reflected)
                FindObjectOfType<BulletsPool>().PullIn(bullet);
        Visual_UImanager.main.SetLife(life);
        if (life <= 0)
            visual.Hit(true);
        else visual.Hit(false);
    }
}

[System.Serializable]
public class Deffensive
{
    public int life;
    public float speed;
}

[System.Serializable]
public class Offensive
{
    public float cooldown;
    public int damage;
    public float parry_duration;
}
