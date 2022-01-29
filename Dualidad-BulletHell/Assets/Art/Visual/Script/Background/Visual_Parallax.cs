using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visual_Parallax : MonoBehaviour
{
    [SerializeField] bool inUpdate;
    [SerializeField] Transform transformReference;
    Vector3 initialPositionReference;
    Vector3 distanceInitialPosition;

    [SerializeField, Range(-2, 3)] float force;
    [SerializeField, Range(0, 10)] float correctorForce;

    [SerializeField] ElementParallax[] planes;

    private void Start() { SetPosition(); }
    private void Update() { if (!inUpdate) return; MoveParallax(); }


    void SetPosition() {
        initialPositionReference = transformReference.position;
        foreach (ElementParallax plane in planes) { plane.SetInitial(); }
    }
    public void MoveParallax() {
        distanceInitialPosition = initialPositionReference - transformReference.position;
        foreach (ElementParallax plane in planes) { plane.SetPosition(distanceInitialPosition * force * correctorForce); }
    }

}

[System.Serializable]
public class ElementParallax {
    [SerializeField] string name;

    public Transform pivotTransform;

    [Range(-2,2)]public float weight;
    [Range(-10, 10)] public float correctionSpeed;
    public Vector3 initialPosition;

    public void SetInitial() { initialPosition = pivotTransform.position; }
    public void SetPosition(Vector3 referenceDistance) { pivotTransform.position = initialPosition + referenceDistance * weight; }
}