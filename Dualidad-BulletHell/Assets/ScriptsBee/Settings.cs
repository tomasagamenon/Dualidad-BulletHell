using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Setting", menuName = "Settings")]
public class Settings : ScriptableObject
{
    public float volumeMaster, volumeSFX, volumeMusic;
}
