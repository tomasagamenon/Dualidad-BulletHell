using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visual_FollowObjects : MonoBehaviour
{
    [SerializeField] bool inUpdate;

    [Header("Reference")]
    [SerializeField] Transform pivot;
    [SerializeField] List<Transform> targets;

    [Header("Construct")]
    [SerializeField] Transform forNull;
    [SerializeField] Vector3 offset;

    void Start() { Follow(); }
    void Update() { if (!inUpdate) return; Follow(); }


    void Follow()  {
        if (ComprobationNull()) return;

        Vector3 newPosition = Vector3.zero;
        foreach (Transform target in targets) newPosition += target.position;

        newPosition = newPosition / targets.Count;
        newPosition.z = 0;
        newPosition += offset;
        pivot.position = new Vector3(newPosition.x, newPosition.y, newPosition.z);
    }

    bool ComprobationNull() {
        if (targets.Count == 0) AddTarget(forNull);
        else if (targets.Count > 1) { foreach (Transform target in targets) { if (target == forNull) { targets.Remove(target); return false; } } }

        return targets.Count == 0;
    }

    public void AddTarget(Transform target)  {
        foreach (Transform targ in targets) if (targ == target) return;
        targets.Add(target);
    }
    public void RemoveTarget(Transform target) { foreach (Transform targ in targets) { if (targ == target) { targets.Remove(target); return; } } }
}
