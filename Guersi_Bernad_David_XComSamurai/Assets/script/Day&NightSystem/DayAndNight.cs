using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayAndNight : MonoBehaviour
{
    [Header("Gradients")]
    [SerializeField]  Gradient fogGradient;
    [SerializeField]  Gradient ambientGradient;
    [SerializeField]  Gradient directionLightGradient;
    [SerializeField]  Gradient skyboxTintGradient;

    [Header("Enviromental Assets")]
    [SerializeField]  Light directionalLight;
    [SerializeField]  Material skyboxMaterial;

    [Header("Variables")]
    [SerializeField]  float dayDurationInSeconds = 60f;
    [SerializeField]  float rotationSpeed = 1f;

     float currentTime = 0;

    private void Update()
    {
        UpdateTime();
        UpdateDayNightCycle();
        RotateSkybox();
    }

    private void UpdateTime()
    {
        currentTime += Time.deltaTime / dayDurationInSeconds;
        currentTime = Mathf.Repeat(currentTime, 1f);
    }

    private void UpdateDayNightCycle()
    {
        float sunPosition = Mathf.Repeat(currentTime + 0.25f, 1f);
        directionalLight.transform.rotation = Quaternion.Euler(sunPosition * 360f, 0f, 0f);

        RenderSettings.fogColor = fogGradient.Evaluate(currentTime);
        RenderSettings.ambientLight = ambientGradient.Evaluate(currentTime);

        directionalLight.color = directionLightGradient.Evaluate(currentTime);

        skyboxMaterial.SetColor("_Tint", skyboxTintGradient.Evaluate(currentTime));
    }

    private void RotateSkybox()
    {
        float currentRotation = skyboxMaterial.GetFloat("_Rotation");
        float newRotation = currentRotation + rotationSpeed * Time.deltaTime;
        newRotation = Mathf.Repeat(newRotation, 360f);
        skyboxMaterial.SetFloat("_Rotation", newRotation);
    }

    private void OnApplicationQuit()
    {
        skyboxMaterial.SetColor("_Tint", new Color(0.5f, 0.5f, 0.5f));
    }
}
