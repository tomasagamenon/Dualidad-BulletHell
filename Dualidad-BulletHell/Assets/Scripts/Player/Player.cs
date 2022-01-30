using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public float speed;
    public float rotation_speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float translationy = Input.GetAxis("Vertical") * speed;
        float translationx = Input.GetAxis("Horizontal") * speed;

        translationy *= Time.deltaTime;
        translationx *= Time.deltaTime;

        transform.Translate(translationx, translationy, 0, Space.World);
        Vector3 lookAtPos = new Vector3(translationx, translationy, 0);
        if(lookAtPos.magnitude > 0)
        {
            Quaternion newRotation = Quaternion.LookRotation(transform.forward, lookAtPos);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, newRotation, Time.deltaTime * rotation_speed);
        }
    }

    public override void GetDamage(int damage)
    {
        base.GetDamage(damage);
        var bullets = FindObjectsOfType<Bullet>();
        foreach (Bullet bullet in bullets)
            if (!bullet.reflected)
                FindObjectOfType<BulletsPool>().PullIn(bullet);
    }
}
