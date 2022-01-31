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
    private int static_life;
    public int score_damage;

    private void Start()
    {
        visual = GetComponent<Visual_Player>();
        Visual_UImanager.main.SetLife(life, static_life);
    }

    void Update()
    {
        float translationy = Input.GetAxis("Vertical");
        float translationx = Input.GetAxis("Horizontal");

        visual.Move(new Vector2(-translationx, translationy));

        if (static_life != defensive[LevelSystem.main.GetLv_Defensive()].life)
        {
            life = defensive[LevelSystem.main.GetLv_Defensive()].life;
            static_life = defensive[LevelSystem.main.GetLv_Defensive()].life;
            Visual_UImanager.main.SetLife(life, static_life);
        }

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
        FindObjectOfType<EnemyWaves>().general_score -= score_damage;
        Visual_UImanager.main.SetScore(FindObjectOfType<EnemyWaves>().general_score);
        var bullets = FindObjectsOfType<Bullet>();
        foreach (Bullet bullet in bullets)
            if (!bullet.reflected)
                FindObjectOfType<BulletsPool>().PullIn(bullet);
        Visual_UImanager.main.SetLife(life, static_life);
        if (life <= 0)
        {
            visual.Hit(true);
            Visual_UImanager.main.SetScreen(TypeScreen.GameOver);
        }
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
    public float bullet_speed;
}
