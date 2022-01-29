using UnityEngine;

public class AudioToObject : MonoBehaviour
{
    [Header("SFX")]
    [SerializeField] SFX_sound[] sfxClip;

    public void PlaySFX(string SFXName)
    {
        SFX_sound sfxPlay = System.Array.Find(sfxClip, sfx => sfx.name == SFXName);
        if (sfxPlay != null) sfxPlay.Play();
    }
}
