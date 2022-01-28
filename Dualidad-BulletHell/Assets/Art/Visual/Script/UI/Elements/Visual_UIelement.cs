using UnityEngine;

public class Visual_UIelement : MonoBehaviour
{
    public Animator anim;


    public virtual void SetAnimator(string action) { anim.SetTrigger(action); }
    public virtual void SetAnimator(bool state, string action) { anim.SetBool(action, state); }
    public virtual void SetAnimator(float value, string action) { anim.SetFloat(action, value); }
}
