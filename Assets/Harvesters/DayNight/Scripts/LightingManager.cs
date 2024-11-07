using UnityEngine;

[ExecuteAlways]
public class LightingManager : MonoBehaviour
{
    //Scene References
    [SerializeField] private Light directionalLight;
    [SerializeField] private LightingPreset preset;
    [SerializeField] private Light housePointLight;
    //Variables
    [SerializeField, Range(0, 24)] private float timeOfDay;


    private void Update()
    {
        if (Application.isPlaying)
        {
            //(Replace with a reference to the game time)
            timeOfDay += Time.deltaTime/5f;
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

        directionalLight.color = preset.directionalColor.Evaluate(timePercent);
        directionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 0, 0));
        housePointLight.intensity = preset.pointLightIntensity.Evaluate(timePercent) * 40;

    }
}