using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParryShield : MonoBehaviour
{
    public float cooldown;
    public bool _is_in_cooldown = false;
    public bool _is_in_parry = false;
    public float time_in_parry;
    public float speed_rot;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !_is_in_parry && !_is_in_cooldown)
            StartCoroutine(Parry());
        Vector3 rotate = Vector3.zero;
        var parent = GetComponentInParent<Player>();
        var v3 = Input.mousePosition;
        v3 = Camera.main.ScreenToWorldPoint(v3);
        v3.z = 0;
        if (v3.x < transform.parent.position.x)
        {
            if (v3.y < parent.transform.position.y)
                rotate.z = 140;
            if (v3.y > parent.transform.position.y)
                rotate.z = 50;
        }
        else if (v3.x > parent.transform.position.x)
        {
            if (v3.y < parent.transform.position.y)
                rotate.z = 230;
            if (v3.y > parent.transform.position.y)
                rotate.z = 320;
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, rotate.z), Time.deltaTime * speed_rot);
    }

    IEnumerator InCooldown()
    {
        yield return new WaitForSeconds(cooldown);
        _is_in_cooldown = false;
    }

    IEnumerator Parry()
    {
        _is_in_parry = true;
        yield return new WaitForSeconds(time_in_parry);
        _is_in_parry = false;
        _is_in_cooldown = true;
        StartCoroutine(InCooldown());
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Bullet>() && _is_in_parry)
        {
            var v3 = Input.mousePosition;
            v3 = Camera.main.ScreenToWorldPoint(v3);
            v3.z = 0;
            collision.GetComponent<Bullet>().Reflect(v3);
        }
    }
}
