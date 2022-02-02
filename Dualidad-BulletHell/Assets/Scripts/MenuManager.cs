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
        FindObjectOfType<ParryShield>().enabled = false;
        Visual_UImanager.main.SetScreen(screen);
    }

    void Start()
    {
        if (screen == TypeScreen.Gameplay)
        {
            TimerSystem.main.Play();
            FindObjectOfType<ParryShield>().enabled = true;
            FindObjectOfType<Visual_Player>().ParryState(!false);
        }
        else
        {
            FindObjectOfType<ParryShield>().enabled = false;
            TimerSystem.main.Stop();
        }
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
        FindObjectOfType<Visual_Player>().ParryState(!false);
        FindObjectOfType<ParryShield>().enabled = true;
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

    public void Lose()
    {
        screen = TypeScreen.GameOver;
        Visual_UImanager.main.SetScreen(TypeScreen.GameOver);
    }

    public void Win()
    {
        screen = TypeScreen.Win;
        Visual_UImanager.main.SetScreen(TypeScreen.Win);
    }
}
