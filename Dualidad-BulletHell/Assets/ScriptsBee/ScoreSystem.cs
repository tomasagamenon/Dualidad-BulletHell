using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public static ScoreSystem main;
    private void Awake() {
        if (main == null) main = this; else Destroy(this.gameObject);
        Initializer();
    }

    public int score;

    void Initializer() {
        score = 0;
    }

    public void AddScore(int newScore)
    {
        score += newScore ;

        PlaySFX("AddScore");

        Visual_UImanager.main.SetScore(score);
    }
    public void ResetScore() { score = 0; Visual_UImanager.main.SetScore(score); }


    [Header("SFX")] [SerializeField] SFX_sound[] sfxClip;
    public void PlaySFX(string SFXName)
    {
        SFX_sound sfxPlay = System.Array.Find(sfxClip, sfx => sfx.name == SFXName);
        if (sfxPlay != null) sfxPlay.Play();
    }
}
