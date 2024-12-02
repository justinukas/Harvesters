using UnityEngine;

public class SeedParticleEmission : MonoBehaviour
{
    private ParticleSystem seedParticles;

    private void OnEnable()
    {
        seedParticles = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        float angle = Vector3.Angle(transform.up, Vector3.up);

        // Check if pointing down by at least 100 degrees on X or Y
        if (angle >= 100f)
        {
            EmitParticles();
        }
    }

    private void EmitParticles()
    {
        seedParticles.Emit(1);
    }
}
