using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    protected Transform _target;
    public float radius;
    public float speed;
    public float rotation_speed;
    protected Vector3 _pos_to_go;
    protected bool _ready_to_go = false;


    public List<Paterns> paterns;
    protected BulletsPool bulletsPool;
    protected Player player;

    public int score;

    protected Visual_Enemy visual;
    protected override void Start()
    {
        base.Start();
        bulletsPool = FindObjectOfType<BulletsPool>();
        player = FindObjectOfType<Player>();
        _target = player.transform;
        _pos_to_go = transform.position;
        StartCoroutine(Shoot(1, null, 1));
        visual = GetComponent<Visual_Enemy>();
    }

    protected virtual void Update()
    {
        if ((player.transform.position - transform.position).magnitude < radius * 5)
        {
            Vector3 dir = Vector3.zero;
            if ((player.transform.position - transform.position).magnitude < radius * 3)
            {
                if ((_pos_to_go - player.transform.position).magnitude > radius * 2)
                {
                    _pos_to_go = RandomPointOnCircleEdge(radius);
                    StopAllCoroutines();
                    _ready_to_go = true;
                }
                dir = (_pos_to_go - transform.position).normalized;
            }
            else
            {
                dir = (player.transform.position - transform.position).normalized;
                StopAllCoroutines();
            }
            transform.position += dir * speed * Time.deltaTime;
            if (dir.magnitude > 0)
            {
                Quaternion newRotation = Quaternion.LookRotation(transform.forward, dir);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, newRotation, Time.deltaTime * rotation_speed);
            }
            else
            {
                dir = (player.transform.position - transform.position).normalized;
                Quaternion newRotation = Quaternion.LookRotation(transform.forward, dir);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, newRotation, Time.deltaTime * 700);
            }
            if (0.1f >= (_pos_to_go - transform.position).magnitude && _ready_to_go)
            {
                transform.position = _pos_to_go;
                StartCoroutine(Shoot(1, null, 1));
                _ready_to_go = false;
            }
        }
    }

    IEnumerator Move()
    {
        yield return new WaitForSeconds(1);
        _pos_to_go = RandomPointOnCircleEdge(radius);
        _ready_to_go = true;
    }

    private Vector3 RandomPointOnCircleEdge(float radius)
    {
        var vector2 = Random.insideUnitCircle.normalized * radius;
        var vector3 = new Vector3(vector2.x, vector2.y, 0) + _target.position;
        return vector3;
    }

    protected IEnumerator Shoot(int a, Paterns patern, float time)
    {
        yield return new WaitForSeconds(time);
        if (patern == null)
        {
            if (paterns.Count > 1)
                patern = paterns[Random.Range(0, paterns.Count)];
            else patern = paterns[0];
            if (patern.mirrored)
                StartCoroutine(Shoot(-1, patern, 0));
        }
        for (int i = 0; i < patern.number_of_shoots; i++)
        {
            for (int e = 0; e < patern.number_of_bullets; e++)
            {
                visual.Shoot();
                Bullet bullet = bulletsPool.PullOut();
                bullet.transform.position = transform.position;
                Vector3 rot = Vector3.zero;
                if (patern.distance_between_bullets > 0)
                    rot.z += patern.distance_between_bullets * e;
                else rot.z += (360 / patern.number_of_bullets) * e;
                rot.z += patern.rot_per_shoot * i * a;
                rot.z += patern.ofset_player;
                rot.z += Mathf.Abs(transform.rotation.eulerAngles.z);
                bullet.transform.rotation = Quaternion.Euler(0, 0, rot.z);
                bullet.dir = bullet.transform.up;
            }
            yield return new WaitForSeconds(patern.time_between_bullets);
        }
        StartCoroutine(Move());
    }

    public override void GetDamage(int damage)
    {
        base.GetDamage(damage);
        visual.SetLife(life);
        if (life <= 0)
            visual.Hit(true);
        else
            visual.Hit(false);
    }

    protected override void Death()
    {
        base.Death();
        FindObjectOfType<EnemyWaves>().EnemyDeath(score);
        Destroy(gameObject);
    }
}

[System.Serializable]
public class Paterns
{
    public int number_of_shoots;
    public int number_of_bullets;
    public float time_between_bullets;
    public float distance_between_bullets;
    public float rot_per_shoot;
    public float ofset_player;
    public bool mirrored;
}