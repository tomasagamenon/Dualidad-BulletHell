using UnityEngine;

public class Visual_Bullets : Visual_ElementWorld
{
    [SerializeField] Color colorBullet;
    [SerializeField, Range(0, 2)] float size, speed;

    [SerializeField] Transform transf, pivotScale;
    [SerializeField] SpriteRenderer spr;

    private void Start() {
        SetBullet(colorBullet, size);
        Speed(speed);
    }

    public void SetBullet(Color color, float modSize)
    {
        spr.color = color;
        transf.localScale = Vector3.one * size * modSize;
    }

    public void Speed(float speed_) { speed = speed_;  pivotScale.localScale = new Vector3(.85f, speed_); }
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
