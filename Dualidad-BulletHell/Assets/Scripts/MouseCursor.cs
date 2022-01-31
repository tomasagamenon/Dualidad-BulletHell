using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    private Visual_UImouse visual;
    private MenuManager menu_manager;
    private typeMouse type;
    void Awake()
    {
        Cursor.visible = false;
        visual = GetComponent<Visual_UImouse>();
        menu_manager = FindObjectOfType<MenuManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 cursor_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursor_pos;
        if (menu_manager.public_screen == TypeScreen.Gameplay)
        {
            if (type != typeMouse.inGameplay)
            {
                visual.SetMouse(typeMouse.inGameplay);
                type = typeMouse.inGameplay;
            }
        }
        else if (type != typeMouse.inMenu)
        {
            visual.SetMouse(typeMouse.inMenu);
            type = typeMouse.inMenu;
        }

        if (Input.GetButtonDown("Fire1"))
            visual.Press();
    }
}
