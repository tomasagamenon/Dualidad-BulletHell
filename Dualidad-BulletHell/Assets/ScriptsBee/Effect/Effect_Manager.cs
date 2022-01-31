using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_Manager : MonoBehaviour
{
    public static Effect_Manager main;
    private void Awake() { main = this; }


    public void InstantiateEffect(Vector3 position, string name) { PoolManager.main.GetObject_InPool(name).GetComponent<Effect_Controller>().Spawn(position); }
    public void InstantiateEffect_PopUp(Vector3 position, string text, Color color) {
        PoolManager.main.GetObject_InPool("PopUp").GetComponent<Effect_popUpController>().Spawn(position, text, color);
    }
    public void InstantiateEffect_Explosion(Vector3 position, float size) {
        PoolManager.main.GetObject_InPool("Explosion").GetComponent<Effect_Controller>().Spawn(position, size);
    }
}
