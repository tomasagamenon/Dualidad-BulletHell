using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visual_Player : Visual_ElementWorld
{
    [SerializeField] ScreenShakes[] screenShakes;
    public void PlayShake(string nameShake) {
        ScreenShakes shakePlay = System.Array.Find(screenShakes, sfx => sfx.name == nameShake);
        if (shakePlay != null) shakePlay.Activate();
    }

    public void Move(Vector2 direction) {
        SetAnimator("Mov_X", direction.x);
        SetAnimator("Mov_Y", direction.y);
    }
    public void ParryState(bool state) {
        SetAnimator("Active", state);

        if (state) { PlaySFX("Active"); } else { PlaySFX("Inactive"); }
    }
    public void ActionParry(bool contact, bool cooldown) {
        if (cooldown) {
            SetAnimator("Action");
            if (contact) {
                PlayShake("Parry_good");
                PlaySFX("Parry_good");
            } else {
                PlaySFX("Parry_none");
            }
        }
        else {
            PlayShake("Parry_bad");
            PlaySFX("Parry_bad");
        }
    }
    public void Hit(bool isDeath) {
        SetAnimator("Hit");
        PlayShake("Hit");
        PlaySFX("Hit");
        if (isDeath) { SetAnimator("Death"); PlaySFX("Death"); }
    }
    public void Spawn() {
        SetAnimator("Spawn");
        PlaySFX("Spawn");
    }

}
