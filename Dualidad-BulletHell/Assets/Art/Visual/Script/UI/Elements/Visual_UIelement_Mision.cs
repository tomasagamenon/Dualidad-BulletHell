using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Visual_UIelement_Mision : Visual_UIelement
{
    [SerializeField] TextMeshProUGUI text_Mision;
    int length;
    public void SetMision(string[] text) {

        if (length > text.Length) PlaySFX("Add"); else PlaySFX("Complete");
        length = text.Length;

        foreach (string mision in text) { text_Mision.SetText(mision + "\n"); }
    }
}
