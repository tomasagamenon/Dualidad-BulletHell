using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float dist_from_player;
    public int damage;
    private Player player;
    public Vector3 dir;
    public bool reflected;


    private Visual_Bullets visual;
    [SerializeField] Color color_bullet_reflect;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        visual = GetComponent<Visual_Bullets>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dist_from_player < (player.transform.position - transform.position).magnitude)
            PullIn();
        Move();
    }

    void Move()
    {
        transform.position += dir * speed * Time.deltaTime;
    }

    public void Reflect(Vector3 mousePos)
    {
        visual.SetBullet(color_bullet_reflect, 1);
        visual.Speed(new Vector2(0.7f, 1));
        dir = (mousePos - transform.position).normalized;
        reflected = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() && !reflected)
        {
            collision.GetComponent<Player>().GetDamage(damage);
            visual.Contact();
        }
        if ((collision.GetComponent<Enemy>() || collision.GetComponent<Novato>()) && reflected)
        {
            collision.GetComponent<Enemy>().GetDamage(damage);
            reflected = false;
            visual.Contact();
        }
    }

    public void PullIn()
    {
        if (reflected)
            speed -= player.offensive[LevelSystem.main.GetLv_Offensive()].bullet_speed;
        FindObjectOfType<BulletsPool>().PullIn(this);
    }
}
