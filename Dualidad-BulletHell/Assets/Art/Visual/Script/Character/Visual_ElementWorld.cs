using UnityEngine;

public class Visual_ElementWorld : MonoBehaviour
{
    [SerializeField] Animator anim;

    [SerializeField] SFX_sound[] sfxClip;

    public void PlaySFX(string SFXName) {
        SFX_sound sfxPlay = System.Array.Find(sfxClip, sfx => sfx.name == SFXName);
        if (sfxPlay != null) sfxPlay.Play();
    }

    public void SetAnimator(string action, bool state) { if(anim) anim.SetBool(action, state); }
    public void SetAnimator(string action, float value) { if (anim) anim.SetFloat(action, value); }
    public void SetAnimator(string action) { if (anim) anim.SetTrigger(action); }
}
