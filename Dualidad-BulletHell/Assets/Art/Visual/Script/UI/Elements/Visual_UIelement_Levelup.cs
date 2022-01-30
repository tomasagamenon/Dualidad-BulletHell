using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visual_UIelement_Levelup : Visual_UIelement
{
    public void SetActive(bool state) {
        if (state) {
            anim.gameObject.SetActive(true);
            PlaySFX("Show");
        } else {
            Invoke("Hide", 1);
            PlaySFX("Hide");
        }
        SetAnimator(state, "Active");
    }
    void Hide() { anim.gameObject.SetActive(false); }
}
