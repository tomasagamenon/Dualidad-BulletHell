﻿using UnityEngine;
using Cinemachine;
using System.Collections;

[ExecuteInEditMode]
[SaveDuringPlay]
[AddComponentMenu("")] // Hide in menu

public class Visual_CameraShakeCM : CinemachineExtension
{
    public static Visual_CameraShakeCM main;
    protected override void Awake()
    {
        base.Awake();
        main = this;
    }

    float m_RangeX = 0.5f;
    float m_RangeY = 0.5f;
    float m_rotate = 0;
    float rotation;

    private float m_RangeZ = 0;

    private float shakeTimer;

    protected override void PostPipelineStageCallback(
        CinemachineVirtualCameraBase vcam,
        CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (stage == CinemachineCore.Stage.Body)
        {
            Vector3 shakeAmount = GetOffset();
            state.PositionCorrection += shakeAmount;
            Quaternion shakeRoation = GetRotation();
            state.OrientationCorrection = shakeRoation;
        }
    }

    public void Update()
    {
        //shakeTimer -= Time.deltaTime;
        //if (shakeTimer <= 0) enabled = false;
    }

    public void SetShake(float xAmplitude, float yAmplitude, float rotAmplitude, float time)
    {
        shakeTimer = time;
        m_RangeX = xAmplitude;
        m_RangeY = yAmplitude;
        m_rotate = rotAmplitude;

        enabled = true;
        StopAllCoroutines();
        StartCoroutine(Shake());
    }
    
    IEnumerator Shake()
    {
        yield return new WaitForSecondsRealtime(shakeTimer);
        enabled = false;
    }

    public void Stop() { enabled = false; }

    Vector3 GetOffset()
    {
        return new Vector3(
            Random.Range(-m_RangeX, m_RangeX),
            Random.Range(-m_RangeY, m_RangeY),
            Random.Range(-m_RangeZ, m_RangeZ));
    }
    Quaternion GetRotation()
    {
        rotation = m_rotate * Mathf.Sin(shakeTimer);
        return Quaternion.Euler(0, 0, rotation);
    }
}

[System.Serializable]
public class ScreenShakes
{
    public string name;
    [Range(0, 2)] public float intensity = 1;
    public Vector2 vector;
    [Range(-90, 90)] public float rotation;
    [Range(0, 2)] public float timer;

    public void Activate() { Visual_CameraShakeCM.main.SetShake(vector.x * intensity, vector.y * intensity, rotation, timer); }
}