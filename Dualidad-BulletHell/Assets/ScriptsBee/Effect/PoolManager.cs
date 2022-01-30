using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager main;
    private void Awake() { main = this; }

    [SerializeField] List<Pool> pools;
    [SerializeField] Transform parentPool, parentSpawn;
    GameObject newObject;


    private void OnEnable() { Initializer(); }
    void Initializer() {
        foreach (Pool pool in pools) {
            for (int i = 0; i < pool.initialSpawner; i++) {
                newObject = Instantiate(pool.prefab, transform);
                newObject.transform.SetParent(parentPool);
                pool.AddObject(newObject);
                newObject.SetActive(false);
            }
        }
    }

    public GameObject GetObject_InPool(string namePool) {
        newObject = System.Array.Find(pools.ToArray(), pool => pool.name == namePool).GetObject();
        newObject.SetActive(true);
        newObject.transform.SetParent(parentSpawn);
        return newObject;
    }
    public void HideObject(GameObject object_) {
        foreach (Pool pool in pools)
        {
            newObject = System.Array.Find(pool.objects.ToArray(), pool_ => pool_ == object_);
            if (newObject != null) {
                newObject.SetActive(false);
                newObject.transform.SetParent(parentPool);
                return;
            }
        }
      
    }
}

[System.Serializable]
public class Pool {
    public string name;
    public GameObject prefab;
    [Range(0, 50)] public int initialSpawner;
    [HideInInspector] public List<GameObject> objects;

    public void AddObject(GameObject newGameobject) { objects.Add(newGameobject); }
    public void RemoveObject(GameObject newGameobject) { objects.Remove(newGameobject); }

    public GameObject GetObject() {
        foreach (GameObject obj_ in objects) {
            if (!obj_.activeSelf) {
                return obj_;
            }
        }
        return null;
    }
}