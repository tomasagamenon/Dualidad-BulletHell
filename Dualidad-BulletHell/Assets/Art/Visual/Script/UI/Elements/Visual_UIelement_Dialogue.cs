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

    public bool inDialogue;

    Sprite currentFace;
    string currentText;

    public void SetDialogue(Dialogue dialogue) {
        if (currentFace != dialogue.sprite) {
            currentFace = dialogue.sprite;
            image.sprite = dialogue.sprite;
            SetAnimator("ChangeFace");
        }
        if (currentText != dialogue.text) {
            currentText = dialogue.text;

            anim.gameObject.SetActive(true);

            SetAnimator("ChangeText");

            StopAllCoroutines();
            StartCoroutine(StartDialogue(dialogue.text, dialogue.speedDialogue));
        }
        ReplaceSFX("Char", dialogue.charClip);
    }

    IEnumerator StartDialogue(string text, float speedChar_ ) {

        inDialogue = true;
        SetAnimator(true, "Active");
        text_Dialogue.SetText("");

        PlaySFX("Show");

        foreach (char character in text.ToCharArray()) {

            text_Dialogue.SetText(text_Dialogue.text + character);
            PlaySFX("Char");

            yield return new WaitForSeconds(speedChar_);
        }

        yield return new WaitForSeconds(timeToclose);

        inDialogue = false;

        DialogueSystem.main.RemoveDialogue_First();
        DialogueSystem.main.CheckDialogue();

        SetAnimator(false, "Active");
        PlaySFX("Hide");

        StartCoroutine(Hide());
    }
    IEnumerator Hide() { yield return new WaitForSeconds(1); anim.gameObject.SetActive(false); }
}


