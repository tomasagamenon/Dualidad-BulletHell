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
        if (screen == TypeScreen.Gameplay)
            TimerSystem.main.Play();
        else TimerSystem.main.Stop();
    }

    void Update()
    {
        public_screen = screen;
        if (Input.GetKeyDown(KeyCode.Escape) && (screen == TypeScreen.Gameplay || screen == TypeScreen.Pause))
        {
            if (screen != TypeScreen.Pause)
            {
                TimerSystem.main.Pause();
                Visual_UImanager.main.SetScreen(TypeScreen.Pause);
                screen = TypeScreen.Pause;
            } else if(screen == TypeScreen.Pause)
            {
                TimerSystem.main.Play();
                Visual_UImanager.main.SetScreen(TypeScreen.Gameplay);
                screen = TypeScreen.Gameplay;
            }
        }
    }

    public void Gamplay()
    {
        TimerSystem.main.Play();
        Visual_UImanager.main.SetScreen(TypeScreen.Gameplay);
        screen = TypeScreen.Gameplay;
    }

    public void Retry()
    {
        TimerSystem.main.Stop();
        screen = TypeScreen.Gameplay;
        Time.timeScale = 1;
        TimerSystem.main.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        TimerSystem.main.Stop();
        screen = TypeScreen.MainMenu;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
