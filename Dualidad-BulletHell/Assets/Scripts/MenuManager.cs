using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static TypeScreen screen;
    public TypeScreen public_screen;

    private void Awake()
    {
        Visual_UImanager.main.SetScreen(screen);
    }

    void Start()
    {

    }

    void Update()
    {
        public_screen = screen;
        if (Input.GetKeyDown(KeyCode.Escape) && (screen == TypeScreen.Gameplay || screen == TypeScreen.Pause))
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
        screen = TypeScreen.Gameplay;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        screen = TypeScreen.MainMenu;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
