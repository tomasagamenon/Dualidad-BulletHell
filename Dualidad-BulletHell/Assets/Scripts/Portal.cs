using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public int score_novato;
    public Vector3 spawn;
    public float dist_from_player;
    private void Start()
    {
        GetComponent<Visual_Portal>().Spawn();
    }
    private void Update()
    {
        if ((FindObjectOfType<Player>().transform.position - transform.position).magnitude > dist_from_player)
        {
            var pos = FindObjectOfType<Player>().transform.position + spawn;
            transform.position = pos;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Player>())
        {
            GetComponent<Visual_Portal>().Contact();
            if (FindObjectOfType<Novato>())
            {
                Destroy(FindObjectOfType<Novato>().gameObject);
                FindObjectOfType<EnemyWaves>().general_score += score_novato;
                Visual_UImanager.main.SetScore(FindObjectOfType<EnemyWaves>().general_score);
            }
        }
    }
    public void Destroy()
    {
        FindObjectOfType<EnemyWaves>().next_level = true;
        Visual_UImanager.main.SetLevelup(false);
        Destroy(gameObject);
    }
}
