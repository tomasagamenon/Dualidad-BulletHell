using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Visual_UIelement_Notification : Visual_UIelement
{
    [SerializeField] float correctorSpeed;
    [SerializeField] TextMeshProUGUI text_Notif;

    public void SetNotification(float speed, string text) {

        anim.gameObject.SetActive(true);

        PlaySFX("Show");

        text_Notif.SetText(text);

        SetAnimator("Spawn");
        SetAnimator(correctorSpeed * speed, "Speed");

        Invoke("Hide", correctorSpeed * speed);
    }

    void Hide() { anim.gameObject.SetActive(false); }
}