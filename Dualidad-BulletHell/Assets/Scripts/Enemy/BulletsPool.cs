using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsPool : MonoBehaviour
{
    public Transform parent;

    public Bullet bulletPrefab;
    public List<Bullet> bullets_in_use;
    public List<Bullet> bullets_not_in_use;

    public void PullIn(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
        bullets_in_use.Remove(bullet);
        bullets_not_in_use.Add(bullet);
        bullet.transform.position = transform.position;
        bullet.transform.rotation = transform.rotation;
    }

    public Bullet PullOut()
    {
        Bullet bullet;
        if (bullets_not_in_use.Count > 0)
        {
            bullet = bullets_not_in_use[0];
            bullet.GetComponent<Visual_Bullets>().Spawn();
            bullets_not_in_use.Remove(bullet);
            bullets_in_use.Add(bullet);
            bullet.gameObject.SetActive(true);
            bullet.reflected = false;
        } else
        {
            bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.GetComponent<Visual_Bullets>().Spawn();
            bullet.transform.SetParent(parent);
            bullets_in_use.Add(bullet);
        }
        return bullet;
    }
}
