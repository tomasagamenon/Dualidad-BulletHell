using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visual_Bullets : MonoBehaviour
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
}
