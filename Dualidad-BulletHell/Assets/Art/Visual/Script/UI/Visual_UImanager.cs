using UnityEngine;

public class Visual_UImanager : MonoBehaviour
{
    public static Visual_UImanager main;
    private void Awake() { if (main == null) main = this; else Destroy(this.gameObject); }

    [SerializeField] Visual_UIelement_Life scrLife;
    [SerializeField] Visual_UIelement_Score scrScore;
    [SerializeField] Visual_UIelement_Dialogue scrDialogue;
    [SerializeField] Visual_UIelement_Mision scrMision;

    [SerializeField] Visual_UIelement_Notification scrNotification;

    [SerializeField] Visual_UIelement_Levelup scrLevelUp;

    [SerializeField] Visual_UIscreenManager scrScreen;


    public void SetScore(int score) { scrScore.SetScoreText(score); }
    public void SetLife(int value, int max) { scrLife.SetLife(value, max); }

    public void SetDialogue(Dialogue dialogue) { scrDialogue.SetDialogue(dialogue); }

    public void SetNotification(float speed, string text) { scrNotification.SetNotification(speed, text); }
    public void SetMisions(string[] texts) { scrMision.SetMision(texts); }


    public void SetLevelup(bool active) { scrLevelUp.SetActive(active); }

    public void SetScreen(TypeScreen screen) { scrScreen.ChangeScreen(screen); }

}
