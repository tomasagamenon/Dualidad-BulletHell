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
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dist_from_player < (player.transform.position - transform.position).magnitude)
            FindObjectOfType<BulletsPool>().PullIn(this);
        Move();
    }

    void Move()
    {
        transform.position += dir * speed * Time.deltaTime;
    }

    public void Reflect(Vector3 mousePos)
    {
        dir = (mousePos - transform.position).normalized;
        reflected = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() && !reflected)
        {
            collision.GetComponent<Player>().GetDamage(damage);
            FindObjectOfType<BulletsPool>().PullIn(this);
        }
        if(collision.GetComponent<Enemy>() && reflected)
        {
            collision.GetComponent<Enemy>().GetDamage(damage);
            reflected = false;
            FindObjectOfType<BulletsPool>().PullIn(this);
        }
    }
}
