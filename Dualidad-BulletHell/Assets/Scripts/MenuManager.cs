using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    TypeScreen screen;

    private void Awake()
    {
        Visual_UImanager.main.SetScreen(TypeScreen.MainMenu);
        screen = TypeScreen.MainMenu;
    }

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (screen != TypeScreen.Pause)
            {
                Visual_UImanager.main.SetScreen(TypeScreen.Pause);
                screen = TypeScreen.Pause;
            } else if(screen == TypeScreen.Pause)
            {
                Visual_UImanager.main.SetScreen(TypeScreen.Gameplay);
                screen = TypeScreen.Gameplay;
            }
        }
    }

    public void Gamplay()
    {
        Visual_UImanager.main.SetScreen(TypeScreen.Gameplay);
        screen = TypeScreen.Gameplay;
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
