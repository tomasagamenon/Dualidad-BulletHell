using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_Controller : MonoBehaviour
{
    [SerializeField] Animator anim;

    [Range(0,2)] public float speedAnimation;
    [SerializeField, Range(0, 10)] float correctionSpeed;

    [SerializeField] Vector3 offset, offsetRandom;
    [SerializeField, Range(0.1f,2)] float scaleRandom;
    [SerializeField, Range(0.1f, 2)] float speedRandom;
    [SerializeField, Range(-10, 10)] float rotationRandom;

    public virtual void Spawn(Vector3 position) {
        Initializer(position);
    }
    public virtual void Spawn(Vector3 position, string text, Color color)
    {
        Initializer(position);
    }

    void Initializer(Vector3 position)
    {
        anim.SetTrigger("Spawn");
        anim.SetFloat("Speed", speedAnimation * correctionSpeed * Random.Range(0.1f, scaleRandom));

        transform.position = position;

        transform.position += offset + new Vector3(Random.Range(-offsetRandom.x, offsetRandom.x), Random.Range(-offsetRandom.y, offsetRandom.y));
        transform.localScale = Vector3.one + Vector3.one * Random.Range(0, scaleRandom);
        transform.rotation = Quaternion.Euler(0, Random.Range(-rotationRandom, rotationRandom), 0);
    }

    public virtual void Hide() { PoolManager.main.HideObject(gameObject); }
}
