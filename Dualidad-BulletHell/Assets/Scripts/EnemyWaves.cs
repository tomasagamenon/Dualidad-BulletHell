using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaves : MonoBehaviour
{
    public List<Waves> waves;
    private int _num_wave;
    public List<GameObject> end;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    void Update()
    {
        if (_num_wave >= waves.Count)
            foreach (GameObject gameObject in end)
                gameObject.SetActive(true);
    }

    IEnumerator Spawn()
    {
        foreach(Waves wave in waves)
        {
            foreach(Entity enemy in wave.enemies)
            {
                Instantiate(enemy, transform);
            }
            _num_wave++;
        }
        yield return new WaitForSeconds(10);
    }
}


[System.Serializable]
public class Waves
{
    public List<Entity> enemies;
}
