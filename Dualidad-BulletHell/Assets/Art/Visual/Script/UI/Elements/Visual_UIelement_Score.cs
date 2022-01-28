using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Visual_UIelement_Score : Visual_UIelement
{
    [SerializeField] TextMeshProUGUI text_Score;
    [SerializeField] string addText, addZero;

    public void SetScoreText(int value) { text_Score.SetText(addText + "\n" + value.ToString(addZero)); }

}
