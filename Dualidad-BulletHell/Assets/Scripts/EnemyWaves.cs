using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaves : MonoBehaviour
{
    public List<Levels> levels;
    private int _num_wave;
    public List<GameObject> end;
    public List<Vector2> endPos;
    public int num_of_enemies;
    private int _general_score;
    public float notification_time;
    public bool next_level;

    void Start()
    {
        StartCoroutine(Level());
    }

    void Update()
    {

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
            if(level == levels[levels.Count-1])
                Visual_UImanager.main.SetScreen(TypeScreen.Win);
            else
                for (int i = 0; i < end.Count; i++)
                {
                    var pos = FindObjectOfType<Player>().transform.position + new Vector3(endPos[i].x, endPos[i].y, 0);
                    Instantiate(end[i], pos, transform.rotation);
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
