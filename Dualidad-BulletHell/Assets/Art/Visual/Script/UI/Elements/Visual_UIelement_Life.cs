using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Visual_UIelement_Life : Visual_UIelement
{
    [SerializeField] TextMeshProUGUI text_Life;
    [SerializeField] string addText;

    public void SetLife(int value) { text_Life.SetText(addText + value.ToString()); }
}
