using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class Visual_UIelement_Life : Visual_UIelement
{
    [SerializeField] GameObject prefabIcons;
    [SerializeField] List<GameObject> icons;

    [SerializeField] Transform parentIcon;


    public void SetLife(int value, int max) {
        LoadIcon(max);
        SetIcons(value);
    }

    void LoadIcon(int max) {
        icons.Clear();
        RemoveAllChildren(parentIcon.gameObject);
        for (int i = 0; i < max; i++) {
            GameObject obj = Instantiate(prefabIcons, parentIcon);
            icons.Add(obj);
        }
    }
    void SetIcons(int value) {
        int active = 0;
        foreach (GameObject icon in icons) {
            icon.GetComponent<Animator>().SetBool("Active", active < value);
            active++;
        }
    }

    public void RemoveAllChildren(GameObject parent)
    {
        Transform transform;
        for (int i = 0; i < parent.transform.childCount; i++)
        {
            transform = parent.transform.GetChild(i);
            GameObject.Destroy(transform.gameObject);
        }
    }
}
