using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaves : MonoBehaviour
{
    public List<Waves> waves;
    private int _num_wave;
    public List<GameObject> end;
    public List<Vector2> endPos;
    public int num_of_enemies;
    private int _general_score;
    public float notification_time;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    void Update()
    {
        if (_num_wave >= waves.Count)
            for (int i = 0; i < end.Count; i++) 
            {
                var pos = FindObjectOfType<Player>().transform.position + new Vector3(endPos[i].x, endPos[i].y, 0);
                Instantiate(end[i], pos, transform.rotation);
            }
    }

    IEnumerator Spawn()
    {
        foreach(Waves wave in waves)
        {
            Visual_UImanager.main.SetNotification(notification_time, wave.name);
            for (int i = 0; i < wave.enemies.Count; i++)
            {
                var pos = FindObjectOfType<Player>().transform.position + new Vector3(wave.spawns[i].x, wave.spawns[i].y, 0);
                Instantiate(wave.enemies[i], pos, transform.rotation);
                num_of_enemies++;
            }
            _num_wave++;
            yield return new WaitUntil(() => num_of_enemies <= 0);
        }
    }
    void OnDrawGizmosSelected()
    {
        foreach(Waves wave in waves)
        {
            foreach (Vector2 vector2 in wave.spawns)
            {
                Gizmos.color = Color.yellow;
                Gizmos.DrawSphere(vector2, 0.3f);
            }
        }
    }

    public void EnemyDeath(int score)
    {
        num_of_enemies--;
        _general_score += score;
        Visual_UImanager.main.SetScore(_general_score);
    }
}


[System.Serializable]
public class Waves
{
    public string name;
    public List<Entity> enemies;
    public List<Vector2> spawns;
}
