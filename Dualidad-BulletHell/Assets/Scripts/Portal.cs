using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Player>())
        {
            FindObjectOfType<EnemyWaves>().next_level = true;
            GetComponent<Visual_Portal>().Contact();
            if (FindObjectOfType<Novato>())
                Destroy(FindObjectOfType<Novato>().gameObject);
            Visual_UImanager.main.SetLevelup(false);
            Destroy(this);
        }
    }
}
