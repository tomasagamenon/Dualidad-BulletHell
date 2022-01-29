using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visual_Enemy : Visual_ElementWorld
{
    [SerializeField] Transform transf, transfText;
    [SerializeField] Vector3 addOffset;

    [SerializeField] SpriteRenderer[] spr;
    [SerializeField] Color colorEnemy;


    private void Start()
    {
        SetColor(colorEnemy);
    }
    private void Update()
    {
        ControlPositionText();
    }
    void ControlPositionText()
    {
        transfText.position = transf.position + addOffset;
        transfText.rotation = Quaternion.Euler(0, 0, 0);
    }


    public void SetColor(Color color) {
        colorEnemy = color;
        foreach (SpriteRenderer spr_ in spr) { spr_.color = colorEnemy; }
    }


    public void Move(Vector2 direction)
    {
        SetAnimator("Mov_X", direction.x);
        SetAnimator("Mov_Y", direction.y);
    }
    public void TargetState(bool state)
    {
        SetAnimator("Active", state);

        if (state) { PlaySFX("Active"); } else { PlaySFX("Inactive"); }
    }
    public void Shoot()
    {
        SetAnimator("Action");
        PlaySFX("Shoot");
    }
    public void Hit(bool isDeath)
    {
        SetAnimator("Hit");
        PlaySFX("Hit");
        if (isDeath) { SetAnimator("Death"); PlaySFX("Death"); }
    }
    public void Spawn()
    {
        SetAnimator("Spawn");
        PlaySFX("Spawn");
    }

}
