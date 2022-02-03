using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Novato : Enemy
{
    public Dialogue[] dialogues;
    public float time;
    private bool enemy;

    void Start()
    {
        StartCoroutine(Dialogue());
    }

    protected override void Update()
    {
        if (enemy)
            base.Update();
    }

    IEnumerator Dialogue()
    {
        foreach(Dialogue dialogue in dialogues)
        {
            yield return new WaitForSeconds(time);
            dialogue.Talk();
        }
        enemy = true;
        base.Start();
        bulletsPool = FindObjectOfType<BulletsPool>();
        player = FindObjectOfType<Player>();
        _target = player.transform;
        _pos_to_go = transform.position;
        StartCoroutine(Shoot(1, null, time_before_shoot, false, true));
        visual = GetComponent<Visual_Enemy>();
    }

    protected override void Death()
    {
        visual.Hit(true);
        Visual_UImanager.main.SetLevelup(true); 
        GetComponent<CircleCollider2D>().enabled = false;
        base.Death();
        FindObjectOfType<EnemyWaves>().EnemyDeath(score);
        Effect_Manager.main.InstantiateEffect_PopUp(transform.position, "+" + score.ToString(), Color.white);
        enabled = false;
    }
}

[System.Serializable]
public class Character
{
    public Dialogue dialogue;
    public Sprite face;
}
