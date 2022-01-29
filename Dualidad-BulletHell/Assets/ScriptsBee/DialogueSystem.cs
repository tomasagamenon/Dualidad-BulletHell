using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    public static DialogueSystem main;
    private void Awake() { if (main == null) main = this; else Destroy(this.gameObject); }

    [SerializeField] Visual_UIelement_Dialogue scrDialogue;
    public List<Dialogue> listDialogue;

    public void AddDialogue(Dialogue dialogue) { listDialogue.Add(dialogue); CheckDialogue(); }
    public void RemoveDialogue_First() { listDialogue.Remove(listDialogue[0]); }

    public void CheckDialogue(){
        if (scrDialogue.inDialogue) return;
        if (listDialogue.Count == 0) return;

        Visual_UImanager.main.SetDialogue(listDialogue[0].sprite, listDialogue[0].text);
    }

}
[System.Serializable]
public class Dialogue {
    public Sprite sprite;
    [TextArea] public string text;

    [Range(0.1f, 2)] public float speedDialogue;

    public void Talk() { DialogueSystem.main.AddDialogue(this); }
}