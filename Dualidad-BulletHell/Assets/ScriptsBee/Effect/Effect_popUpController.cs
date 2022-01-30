using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Effect_popUpController : Effect_Controller
{
    [SerializeField] TextMeshPro text;

    public override void Spawn(Vector3 position, string newText, Color color)
    {
        base.Spawn(position);
        text.SetText(newText);
        text.color = color;
    }
}
