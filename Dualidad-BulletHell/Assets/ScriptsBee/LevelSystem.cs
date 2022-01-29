using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    public static LevelSystem main;
    private void Awake() { if (main == null) main = this; else Destroy(this.gameObject); }
       
    [SerializeField] int offensive, defensive;

    private void Start() { ResetLV(); }

    public int GetLv_Offensive() { return offensive; }
    public int GetLv_Defensive() { return defensive; }

    public void LevelUp_Offensive() { offensive++; }
    public void LevelUp_Defensive() { defensive++; }

    public void ResetLV() { offensive = defensive = 0; }

}