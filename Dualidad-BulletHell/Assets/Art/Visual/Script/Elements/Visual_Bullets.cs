using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visual_Bullets : Visual_ElementWorld
{
    [SerializeField] Color colorBullet;
    [SerializeField, Range(0, 2)] float size;

    [SerializeField] Transform transf;
    [SerializeField] SpriteRenderer spr;

    private void Start() { SetBullet(colorBullet, size); }
    
    public void SetBullet(Color color, float modSize) {
        spr.color = color;
        transf.localScale = Vector3.one * size * modSize;
    }

    public void Direction(Vector2 direction)
    {
        SetAnimator("Move_X", direction.x);
        SetAnimator("Move_Y", direction.y);
    }
    public void Spawn()
    {
        SetAnimator("Spawn");
        PlaySFX("Spawn");
    }
    public void Contact()
    {
        SetAnimator("Contact");
        PlaySFX("Contact");
    }
}
