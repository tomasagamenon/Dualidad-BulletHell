using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Visual_UIelement_Score : Visual_UIelement
{
    [SerializeField] TextMeshProUGUI text_Score;
    [SerializeField] string addText;
    [SerializeField] int addZero;

    public void SetScoreText(int score) { text_Score.SetText(addText + "\n" + GetText(addZero, score)); }


    string GetText(int zero, int value) {
        string text_ = "<color=#fff>" + value.ToString();
        for (int i = 0; i < (zero - value.ToString().Length); i++) { text_ = "0" + text_; }
        return text_;
    }
}
