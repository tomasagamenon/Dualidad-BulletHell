using System;
using UnityEngine;
using UnityEngine.Audio;

public class Mixer : MonoBehaviour
{
    public string nameMixer;
    [SerializeField] AudioMixer mixer;
    [SerializeField] string nameVarVolume;
    [SerializeField, Range(0.0001f, 1f)] float minVolume, maxVolume;
    [SerializeField, Range(0, 1f)] float volume;

    private void Start() { SetVolume(volume); }

    public void SetEffect(string nameEffect, float value) { mixer.SetFloat(nameEffect, value); }
    public void SetVolume(float value)
    {
        volume = Mathf.Clamp(value, minVolume, maxVolume);
        mixer.SetFloat(nameVarVolume, Mathf.Log10(volume) * 20);
    }

}
