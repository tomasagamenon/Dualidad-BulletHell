using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Visual_UIelement_Mision : Visual_UIelement
{
    [SerializeField] TextMeshProUGUI text_Mision;

    public void SetMision(string[] text) { foreach (string mision in text) { text_Mision.SetText(mision + "\n"); } }
}
