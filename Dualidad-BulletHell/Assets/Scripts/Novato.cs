using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Novato : Enemy
{
    public List<Dialogue> dialogues;
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
        StartCoroutine(Shoot(1, null));
        visual = GetComponent<Visual_Enemy>();
    }
}
