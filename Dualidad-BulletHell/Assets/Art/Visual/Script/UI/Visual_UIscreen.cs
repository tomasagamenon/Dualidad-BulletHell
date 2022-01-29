using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visual_UIscreen : MonoBehaviour
{
    [SerializeField] Animator anim;

    float waitTime;
    [SerializeField, Range(0, 1)] float WaitSecond;
    [SerializeField, Range(0, 5)] float correctionWait;
    [SerializeField, Range(0, 1)] float HideSecond;

    public string toSnapshot;
    [SerializeField, Range(0, 1)] float timeScale_Intro, timeScale_End;

    public virtual void StartScreen()
    {
        ChangeSnapshot();
        ChangeTime(timeScale_Intro);
        if (anim == true)
        {
            anim.gameObject.SetActive(true);
            anim.SetBool("Active", true);
        }

    }
    public virtual void EndScreen()
    {
        ChangeTime(timeScale_End);
        if (anim == true)
        {
            anim.SetBool("Active", false);
            Invoke("Hide", HideSecond);
        }
    }

    void Hide() { anim.gameObject.SetActive(false); }


    public void StateScreen(bool state, float wait)
    {
        waitTime = (WaitSecond * correctionWait) * wait;
        StartCoroutine(Screen(state));
    }
    IEnumerator Screen(bool state) { if (state) { yield return new WaitForSecondsRealtime(waitTime); StartScreen(); } else EndScreen(); }


    void PlaySFX(string SFXName)
    {
        //SFX_sound sfxPlay = System.Array.Find(sfxClip, sfx => sfx.name == SFXName);
        //if (sfxPlay != null) sfxPlay.Play();
    }
    void ChangeSnapshot() { AudioManager.main.ChangeSnapshot("StateGame", toSnapshot); }
    void ChangeTime(float time) { Time.timeScale = time; }
}
