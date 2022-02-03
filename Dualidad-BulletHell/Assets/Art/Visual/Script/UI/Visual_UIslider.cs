using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Visual_UIslider : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] string nameVolume;

    private void Start()
    {
        slider.value = AudioManager.main.GetVolume(nameVolume);
    }
}
