using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visual_UIelement_Levelup : Visual_UIelement
{
    public void SetActive(bool state) {
        if (state) { anim.gameObject.SetActive(true); } else { Invoke("Hide", 1); }
        SetActive(state);       
    }
    void Hide() { anim.gameObject.SetActive(false); }
}
