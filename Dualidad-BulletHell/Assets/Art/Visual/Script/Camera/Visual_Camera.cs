using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Cinemachine;

public class Visual_Camera : MonoBehaviour
{
    public static Visual_Camera main;
    private void Awake() { if (main == null) main = this; else Destroy(this.gameObject); }


    [SerializeField] Visual_FollowObjects scrTarget;
    [SerializeField] float viewBase;

    [SerializeField] CinemachineVirtualCamera virtualCamera;

    private void Start() { Initializer(); }

    void Initializer() {
        SetView(1);
    }

    public void SetView(float view) { virtualCamera.m_Lens.OrthographicSize = viewBase * view; }

    public void AddTarget(Transform newTarget) { scrTarget.AddTarget(newTarget); }
    public void RemoveTarget(Transform remoteTarget) { scrTarget.RemoveTarget(remoteTarget); }
}
