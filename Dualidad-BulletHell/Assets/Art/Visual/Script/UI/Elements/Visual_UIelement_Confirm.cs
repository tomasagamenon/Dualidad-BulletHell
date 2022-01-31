using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visual_UIelement_Confirm : Visual_UIelement
{

    public void SetState(bool state)
    {
        if (state) {
            anim.gameObject.SetActive(true);
            PlaySFX("Show");
        } else {
            StartCoroutine(Hide());
            PlaySFX("Hide");
        }
        SetAnimator(state, "Active");
    }
    IEnumerator Hide() { yield return new WaitForSeconds(1); anim.gameObject.SetActive(false); }
}
