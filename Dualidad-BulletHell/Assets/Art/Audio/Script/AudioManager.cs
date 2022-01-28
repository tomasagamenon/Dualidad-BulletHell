using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager main;

    [Header("====SOURCEs====")]
    [SerializeField] Mixer[] mixers;
    [SerializeField] Source[] sources;
    [SerializeField] EFFECT[] effects;

    [Header("====CLIPs====")]
    [SerializeField] SFX[] sfx;
    [SerializeField] MUSIC[] music;

    [Header("====CONSTRUCT====")]
    [SerializeField, Range(0, 1)] float volumeMaster;
    [SerializeField, Range(0, 1)] float volumeSFX, volumeMusic;


    #region CONSTRUCT
    private void Awake()
    {
        if (main == null)
        {
            main = this;
            Initializer();
        }
        else Destroy(this.gameObject);
    }
    public void Start() { GetReferences(); }

    public void GetReferences()
    {

    }
    public void Initializer()
    {
        foreach (Source source in sources) { source.source.outputAudioMixerGroup = source.mixer; }
    }
    #endregion

    #region FUNCTIONS
    #region CLIPS
    public void PlaySFX(string nameAudio)
    {
        SFX sfx_ = Array.Find(sfx, sound => sound.name == nameAudio);
        if (sfx_ != null) sfx_.PlayAudio();
    }
    public void PlayMUSIC(string nameAudio)
    {
        MUSIC music_ = Array.Find(music, sound => sound.name == nameAudio);
        if (music_ != null) music_.PlayAudio();
    }
    #endregion
    #region EFFECTS
    public void ChangeSnapshot(string nameEffect, string nameSnapshot) { Array.Find(effects, effect => effect.name == nameEffect).SetActive(nameSnapshot); }
    #endregion
    #region VOLUME
    public void SetVolume(Mixer mixerToModify, float volume) { if (mixerToModify) mixerToModify.SetVolume(volume); }
    public void SetVolume_MASTER(float volume)
    {
        volumeMaster = volume;
        SetVolume(Array.Find(mixers, mixer => mixer.nameMixer == "MASTER"), volumeMaster);
    }
    public void SetVolume_SFX(float volume)
    {
        volumeSFX = volume;
        SetVolume(Array.Find(mixers, mixer => mixer.nameMixer == "SFX"), volumeSFX);
    }
    public void SetVolume_MUSIC(float volume)
    {
        volumeMusic = volume;
        SetVolume(Array.Find(mixers, mixer => mixer.nameMixer == "MUSIC"), volumeMusic);
    }
    #endregion
    #endregion

}

[Serializable]
public class EFFECT
{
    public string name;
    public AudioMixer mixer;
    public SNAPSHOT[] snapshots;

    public void SetActive(string nameSnapshot) { Array.Find(snapshots, snapshot => snapshot.name == nameSnapshot).ToTransition(); }
}
[Serializable]
public class SNAPSHOT
{
    public string name;
    [Range(0, 1)] public float timeToReach;
    public AudioMixerSnapshot snapshots;

    public void ToTransition() { snapshots.TransitionTo(timeToReach); }
}

[Serializable]
public class Source
{
    public string name;
    public AudioMixerGroup mixer;
    public AudioSource source;

    public bool playing;
    public bool IsPlaying() { playing = source.isPlaying; return playing; }
}

#region AUDIO
public class Audio
{
    public string name;
    public AudioClip[] clip;
    public AudioSource source;

    [Range(0, 1)] public float volume = 1;

    public virtual void PlayAudio() { }
}

[Serializable] public class SFX : Audio
{
    [Range(0, 2)] public float pitch = 1;
    [Range(0, 1)] public float randomizerPitch = 0;

    public override void PlayAudio()
    {
        source.clip = clip[UnityEngine.Random.Range(0, clip.Length)];
        source.volume = volume * volume;
        source.pitch = pitch + UnityEngine.Random.Range(-randomizerPitch, randomizerPitch);
        source.Play();
    }
}
[Serializable] public class MUSIC : Audio
{
    public override void PlayAudio()
    {
        source.clip = clip[UnityEngine.Random.Range(0, clip.Length)];
        source.volume = volume * volume;
        source.Play();
    }
}

[System.Serializable]  public class SFX_sound
{
    public string name;
    public string nameDataBase;
    public void Play()
    {
        AudioManager.main.PlaySFX(nameDataBase);
    }
}
#endregion
