using UnityEngine;

[ExecuteAlways]
public class LightingManager : MonoBehaviour
{
    //Scene References
    [SerializeField] private Light directionalLight;
    [SerializeField] private LightingPreset preset;
    [SerializeField] private Light housePointLight;
    [SerializeField] private Material newSkybox;
    //Variables
    [SerializeField, Range(0, 24)] private float timeOfDay;

    private Color sunColor = new Color(1f, 0.7661839f, 0f);
    private Color moonColor = new Color(1f, 1f, 1f);
    private int inverse = 1;


    private void Update()
    {
        if (Application.isPlaying)
        {
            //(Replace with a reference to the game time)
            timeOfDay += Time.deltaTime/24f;
            timeOfDay %= 24; //Modulus to ensure always between 0-24
            UpdateLighting(timeOfDay / 24f);
        }
        else
        {
            UpdateLighting(timeOfDay / 24f);
        }
    }


    private void UpdateLighting(float timePercent)
    {
        RenderSettings.ambientLight = preset.ambientColor.Evaluate(timePercent);
        RenderSettings.fogColor = preset.fogColor.Evaluate(timePercent);
        RenderSettings.fogDensity = preset.fogDensity.Evaluate(timePercent) * 0.1f;

        newSkybox.SetColor("_Skycolor", preset.skyColor.Evaluate(timePercent));
        newSkybox.SetFloat("_HorizonBlend", preset.horizonBlend.Evaluate(timePercent));
        newSkybox.SetFloat("_StarPower", preset.starPower.Evaluate(timePercent));

        if (timePercent >= 0.75f || timePercent <= 0.25)
        {
            inverse = -1;
            if (newSkybox.GetColor("_SkylightColor") != moonColor)
            {
                newSkybox.SetColor("_SkylightColor", moonColor);
            }
        }
        else 
        { 
            inverse = 1;

            if (newSkybox.GetColor("_SkylightColor") != sunColor)
            {
                newSkybox.SetColor("_SkylightColor", sunColor);
            }
        }

        newSkybox.SetVector("_MainLightAngle", transform.forward * inverse);

        directionalLight.color = preset.directionalColor.Evaluate(timePercent);
        directionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 0, 0));
        housePointLight.intensity = preset.pointLightIntensity.Evaluate(timePercent) * 40;
    }
}