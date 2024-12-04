using UnityEngine;

public class SeedParticleEmission : MonoBehaviour
{
    private ParticleSystem seedParticles;
    private SeedBagManager seedBagManager;

    private void OnEnable()
    {
        seedParticles = GetComponent<ParticleSystem>();
        seedBagManager = GetComponent<SeedBagManager>();
    }

    private void Update()
    {
        float angle = Vector3.Angle(transform.up, Vector3.up);

        // Check if pointing down by at least 100 degrees on X or Y
        if (angle >= 100f)
        {
            EmitParticles();
        }
        else
        {
            if (seedBagManager.seedsDropping != false)
            {
                seedBagManager.seedsDropping = false;
            }
        }
    }

    private void EmitParticles()
    {
        seedParticles.Emit(1);
        if (seedBagManager.seedsDropping != true)
        {
            seedBagManager.seedsDropping = true;
        }
    }
}
