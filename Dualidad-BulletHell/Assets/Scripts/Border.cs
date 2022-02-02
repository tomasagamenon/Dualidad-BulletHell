using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    public Dialogue[] dialogue;
    int x;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Player>())
        {
            dialogue[x].Talk();
            x++;
            if (x >= dialogue.Length)
                x = 0;
        }
    }
}
