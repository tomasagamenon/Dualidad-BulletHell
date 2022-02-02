using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerSystem : MonoBehaviour
{
    public static TimerSystem main;
    private void Awake() { if (main == null) main = this; else Destroy(this.gameObject); }

    int min, second, milisecond;
    float timer;

    [SerializeField] float milisecondTimer;

    public void Play() { StopAllCoroutines(); StartCoroutine(Timer()); }
    public void Pause() { StopAllCoroutines(); }
    public void Stop() { StopAllCoroutines();  timer = 0; }


    IEnumerator Timer() {

        while (true) {

            timer += milisecondTimer;

            milisecond = (int)timer % 60;
            second = (int)timer / 60;
            min = (int)timer / 3600;

            Visual_UImanager.main.SetTimer(min, second, milisecond);

            yield return new WaitForSeconds(0);
        }
    }
}
