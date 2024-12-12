using UnityEngine;

public class ParticleHandler : MonoBehaviour
{
    public void EmitPlantingParticles(GameObject tilledDirt, ParticleSystem plantParticles)
    {
        ParticleSystem PlantParticlesCopy = Instantiate(plantParticles, tilledDirt.transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
        PlantParticlesCopy.Emit(10);
        PlantParticlesCopy.Stop();
    }
}
