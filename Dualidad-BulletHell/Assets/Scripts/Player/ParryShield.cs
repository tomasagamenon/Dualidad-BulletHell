using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParryShield : MonoBehaviour
{
    //public float cooldown;
    public bool _is_in_cooldown = false;
    public bool _is_in_parry = false;
    //public float time_in_parry;
    public float speed_rot;
    private Offensive[] offensive;
    public Visual_Player visual;
    private bool colision;

    void Start()
    {
        offensive = GetComponentInParent<Player>().offensive;
        visual = GetComponentInParent<Visual_Player>();
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


        var dir = (v3 - transform.position).normalized;
        Quaternion newRotation = Quaternion.LookRotation(transform.forward, dir);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * speed_rot);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, rotate.z), Time.deltaTime * speed_rot);
    }

    IEnumerator InCooldown()
    {
        yield return new WaitForSeconds(offensive[LevelSystem.main.GetLv_Offensive()].cooldown);
        _is_in_cooldown = false;
        visual.ParryState(!_is_in_cooldown);
    }

    IEnumerator Parry()
    {
        _is_in_parry = true;
        visual.ActionParry(false, !_is_in_parry);
        yield return new WaitForSeconds(offensive[LevelSystem.main.GetLv_Offensive()].parry_duration);
        _is_in_parry = false;
        visual.ActionParry(false, !_is_in_parry);
        if(!colision)
        {
            _is_in_cooldown = true;
            visual.ParryState(!_is_in_cooldown);
            StartCoroutine(InCooldown());
        }
        colision = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Bullet>() && _is_in_parry)
        {
            _is_in_cooldown = false;
            colision = true;
            var v3 = Input.mousePosition;
            v3 = Camera.main.ScreenToWorldPoint(v3);
            v3.z = 0;
            collision.GetComponent<Bullet>().Reflect(v3);
            collision.GetComponent<Bullet>().damage = offensive[LevelSystem.main.GetLv_Offensive()].damage;
            visual.ActionParry(true, !_is_in_parry);
        }
    }
}
