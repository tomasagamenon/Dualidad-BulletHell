using UnityEngine;

public class Visual_Bullets : Visual_ElementWorld
{
    [SerializeField] Color colorBullet;
    [SerializeField, Range(0, 2)] float size;

    [SerializeField] Transform transf, pivotScale;
    [SerializeField] SpriteRenderer spr;

    private void OnEnable() {
        SetBullet(colorBullet, size);
    }

    public void SetBullet(Color color, float modSize)
    {
        spr.color = color;
        transf.localScale = Vector3.one * size * modSize;
    }

    public void Speed(Vector2 speed_) { pivotScale.localScale = new Vector3(speed_.x, speed_.y); }
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
