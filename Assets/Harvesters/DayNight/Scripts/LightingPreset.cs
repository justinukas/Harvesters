using UnityEngine;

[CreateAssetMenu(fileName = "Lighting Preset", menuName = "Scriptable Objects/Lighting Preset", order = 1)]
public class LightingPreset : ScriptableObject
{
    public Gradient ambientColor;
    public Gradient directionalColor;
    public Gradient fogColor;
    public AnimationCurve pointLightIntensity;
    public AnimationCurve fogDensity;
}
