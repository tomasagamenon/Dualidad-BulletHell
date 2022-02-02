using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaves : MonoBehaviour
{
    public List<Levels> levels;
    private int _num_wave;
    public List<End> end;
    public int num_of_enemies;
    public int general_score;
    public float notification_time;
    public bool next_level;

    void Start()
    {
        StartCoroutine(Level());
    }

    void Update()
    {
        if (num_of_enemies < 0)
            num_of_enemies = 0;
    }

    IEnumerator Level()
    {
        foreach(Levels level in levels)
        {
            StartCoroutine(Spawn(level.waves, level));
            yield return new WaitUntil(() => next_level);
            next_level = false;
        }
    }

    IEnumerator Spawn(List<Waves> waves, Levels level)
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
            yield return new WaitUntil(() => num_of_enemies <= 0);
            _num_wave++;
        }
        if (_num_wave >= waves.Count)
        {
            if (level == levels[levels.Count - 1])
                FindObjectOfType<MenuManager>().Win();
            else
                for (int i = 0; i < end[levels.IndexOf(level)].objects.Count; i++)
                {
                    Visual_UImanager.main.SetNotification(notification_time, end[i].name);
                    for (int x = 0; x < end[i].objects.Count; i++)
                    {
                        var pos = FindObjectOfType<Player>().transform.position + new Vector3(end[i].spawns[x].x, end[i].spawns[x].y, 0);
                        Instantiate(end[i].objects[x], pos, transform.rotation);
                    }
                }
        }
    }

    public void EnemyDeath(int score)
    {
        num_of_enemies--;
        general_score += score;
        Visual_UImanager.main.SetScore(general_score);
    }
}


[System.Serializable]
public class Levels
{
    public List<Waves> waves;
}

[System.Serializable]
public class Waves
{
    public string name;
    public List<Entity> enemies;
    public List<Vector2> spawns;
}

[System.Serializable]
public class End
{
    public string name;
    public List<GameObject> objects;
    public List<Vector2> spawns;
}
