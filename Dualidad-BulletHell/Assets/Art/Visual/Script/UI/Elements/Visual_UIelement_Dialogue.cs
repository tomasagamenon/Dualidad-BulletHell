using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Visual_UIelement_Dialogue : Visual_UIelement
{
    [SerializeField] TextMeshProUGUI text_Dialogue;
    [SerializeField] Image image;

    [SerializeField, Range(0,1)] float speedChar, timeToclose;

    Sprite currentFace;
    string currentText;

    public void SetDialogue(Sprite spr, string text) {
        if (currentFace != spr) {
            currentFace = spr;
            image.sprite = spr;
            SetAnimator("ChangeFace");
        }
        if (currentText != text) {
            currentText = text;

            anim.gameObject.SetActive(true);

            SetAnimator("ChangeText");

            StopAllCoroutines();
            StartCoroutine(StartDialogue(text));
        }
    }

    IEnumerator StartDialogue(string text) {

        SetAnimator(true, "Active");
        text_Dialogue.SetText("");

        foreach (char character in text.ToCharArray()) {

            text_Dialogue.SetText(text_Dialogue.text + character);

            yield return new WaitForSeconds(speedChar);
        }

        yield return new WaitForSeconds(timeToclose);

        SetAnimator(false, "Active");
        Invoke("Hide", 1);
    }

    void Hide() { anim.gameObject.SetActive(false); }
}


