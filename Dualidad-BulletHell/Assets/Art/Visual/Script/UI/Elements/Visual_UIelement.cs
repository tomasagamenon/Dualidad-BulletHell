using UnityEngine;

public class Visual_UIelement : MonoBehaviour
{
    public Animator anim;

    [SerializeField] SFX_sound[] sfxClip;
    public void PlaySFX(string SFXName)
    {
        SFX_sound sfxPlay = System.Array.Find(sfxClip, sfx => sfx.name == SFXName);
        if (sfxPlay != null) sfxPlay.Play();
    }

    public virtual void SetAnimator(string action) { anim.SetTrigger(action); }
    public virtual void SetAnimator(bool state, string action) { anim.SetBool(action, state); }
    public virtual void SetAnimator(float value, string action) { anim.SetFloat(action, value); }
}
