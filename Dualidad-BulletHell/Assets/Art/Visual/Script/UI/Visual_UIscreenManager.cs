using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visual_UIscreenManager : MonoBehaviour
{
    public GameScreen[] screens;
    GameScreen currentScreen;

    public void ChangeScreen(TypeScreen toScreen)
    {
        GameScreen toNewScreen = System.Array.Find(screens, screen => screen.type == toScreen);
        if (toNewScreen == null) return;

        if (currentScreen != null) currentScreen.State(false);
        currentScreen = toNewScreen;
        currentScreen.State(true);

    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) { ChangeScreen(TypeScreen.MainMenu); }
        if (Input.GetKeyDown(KeyCode.S)) { ChangeScreen(TypeScreen.Gameplay); }
        if (Input.GetKeyDown(KeyCode.D)) { ChangeScreen(TypeScreen.Pause); }
        if (Input.GetKeyDown(KeyCode.F)) { ChangeScreen(TypeScreen.GameOver); }
    }

}

public enum TypeScreen { MainMenu, Gameplay, Pause, GameOver, Cutscene }
[System.Serializable] public class GameScreen
{
    public string name;
    public TypeScreen type;
    public Visual_UIscreen screen;

    public string toSnapshot;
    public string toMusicClip;

    void ChangeMusic() { AudioManager.main.PlayMUSIC(toMusicClip); }
    void ChangeSnapshot() { AudioManager.main.ChangeSnapshot("StateGame", toSnapshot); }

    public void State(bool state) {
        if (screen != null) screen.StateScreen(state, 1);
        if (state) { ChangeMusic(); ChangeSnapshot(); }
    }
}