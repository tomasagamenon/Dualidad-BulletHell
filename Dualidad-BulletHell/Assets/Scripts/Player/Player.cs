using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    //public float speed;
    public float rotation_speed;
    public Defensive[] defensive;
    public Offensive[] offensive;
    public Visual_Player visual;
    public int score_damage;
    public int score_heal;
    private int _trigger = 1;

    protected override void Start()
    {
        life = defensive[LevelSystem.main.GetLv_Defensive()].life;
        max_life = defensive[LevelSystem.main.GetLv_Defensive()].life;
        visual = GetComponent<Visual_Player>();
        Visual_UImanager.main.SetLife(life, max_life);
    }

    void Update()
    {
        Debug.Log(_trigger);
        if (Mathf.RoundToInt(FindObjectOfType<EnemyWaves>().general_score / score_heal) >= _trigger && life < max_life)
        {
            _trigger++;
            life++;
            Visual_UImanager.main.SetLife(life, max_life);
        }
        if (life > max_life)
            life = max_life;

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
        FindObjectOfType<EnemyWaves>().general_score -= score_damage;
        Effect_Manager.main.InstantiateEffect_PopUp(transform.position, "-" + score_damage.ToString(), Color.red);
        Visual_UImanager.main.SetScore(FindObjectOfType<EnemyWaves>().general_score);
        var bullets = FindObjectsOfType<Bullet>();
        foreach (Bullet bullet in bullets)
            if (!bullet.reflected)
                FindObjectOfType<BulletsPool>().PullIn(bullet);
        Visual_UImanager.main.SetLife(life, max_life);
        if (life <= 0)
        {
            visual.Hit(true);
            FindObjectOfType<MenuManager>().Lose();
        }
        else visual.Hit(false);
    }

    public void RefreshValues(bool defense)
    {
        life = defensive[LevelSystem.main.GetLv_Defensive()].life;
        if (defense)
            max_life = defensive[LevelSystem.main.GetLv_Defensive()].life;
        Visual_UImanager.main.SetLife(life, max_life);
    }
}

[System.Serializable]
public class Defensive
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
