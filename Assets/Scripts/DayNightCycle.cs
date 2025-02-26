using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DayNightCycle : MonoBehaviour
{
    public Light2D DayLight;
    public Gradient DayLightGradient;

    public Light2D NightLight;
    public Gradient NightLightGradient;

    public void UpdateLight(int energy)
    {
        float ratio = (50 - energy) / 50.0f;
        DayLight.color = DayLightGradient.Evaluate(ratio);
        NightLight.color = NightLightGradient.Evaluate(ratio);

        transform.rotation = Quaternion.Euler(0, 0, 360.0f * ratio);
    }
}

