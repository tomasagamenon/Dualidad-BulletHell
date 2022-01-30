using UnityEngine;

public class Visual_Portal : Visual_ElementWorld
{
    [SerializeField] Color colorBack, colorFore;
    [SerializeField, Range(0, 2)] float size;

    [SerializeField] Transform transf;
    [SerializeField] SpriteRenderer sprBack, sprFore;

    private void Start() { SetPortal(colorBack, colorFore, size); }

    public void SetPortal(Color colorBack_, Color colorFore_, float modSize)
    {
        sprBack.color = colorBack_;
        sprFore.color = colorFore_;
        transf.localScale = Vector3.one * size * modSize;
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
