using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaves : MonoBehaviour
{
    public List<Levels> levels;
    private int _num_wave;
    public List<End> end;
    public int general_score;
    public float notification_time;
    public bool next_level;

    void Start()
    {
        StartCoroutine(Level());
    }

    void Update()
    {
        if (general_score < 0)
        {
            general_score = 0;
            Visual_UImanager.main.SetScore(general_score);
        }
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
            }
            yield return new WaitUntil(() => FindObjectsOfType<Enemy>().Length <= 0);
            _num_wave++;
        }
        if (_num_wave >= waves.Count)
        {
            if (level == levels[levels.Count - 1])
                FindObjectOfType<MenuManager>().Win();
            else
            {
                Visual_UImanager.main.SetNotification(notification_time, end[levels.IndexOf(level)].name);
                for (int x = 0; x < end[levels.IndexOf(level)].objects.Count; x++)
                {
                    var pos = FindObjectOfType<Player>().transform.position + new Vector3(end[levels.IndexOf(level)].spawns[x].x, end[levels.IndexOf(level)].spawns[x].y, 0);
                    var a = Instantiate(end[levels.IndexOf(level)].objects[x], pos, transform.rotation);
                    if (a.GetComponent<Portal>())
                        a.GetComponent<Portal>().spawn = new Vector3(end[levels.IndexOf(level)].spawns[x].x, end[levels.IndexOf(level)].spawns[x].y, 0);
                }
            }
        }
    }

    public void EnemyDeath(int score)
    {
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
