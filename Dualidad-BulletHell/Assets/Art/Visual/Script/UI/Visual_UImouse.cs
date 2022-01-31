using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visual_UImouse : Visual_UIelement
{
    [SerializeField] typeMouse type;
    [SerializeField] AnimatorOverrideController gameplay, menu;

    public void SetMouse(typeMouse type_) {
        type = type_;
        SetAnimator("Change");
    }
    public void SetState(bool state) { SetAnimator(state, "Active"); }
    public void Press() { SetAnimator("Press"); }
    
    void ChangeOverride() {
        switch (type) {
            case typeMouse.inGameplay:
                anim.runtimeAnimatorController = gameplay;
                break;
            case typeMouse.inMenu:
                anim.runtimeAnimatorController = menu;
                break;
        }
        SetAnimator("Spawn");
    }

}
public enum typeMouse { inGameplay, inMenu }
