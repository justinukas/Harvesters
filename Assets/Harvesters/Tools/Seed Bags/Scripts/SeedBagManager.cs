using UnityEngine;

public class SeedBagManager : MonoBehaviour
{
    [HideInInspector] public int timesUsed;
    [HideInInspector] public int maxTimesUsed = 50;
    [HideInInspector] public string bagVariant;
    [HideInInspector] public GameObject tilledDirt;

    [Header("Prefabs For Scripts")]
    [SerializeField] ParticleSystem plantParticles;
    [SerializeField] GameObject Wheat;
    [SerializeField] GameObject Carrot;

    private CollisionChecker collisionChecker;
    private PlantInfoHandler plantInfoHandler;
    private PlantSpawningHandler plantSpawningHandler;
    private ColorHandler colorHandler;
    private SoundHandler soundHandler;
    private ParticleHandler particleHandler;

    private void Start()
    {
        collisionChecker = GetComponent<CollisionChecker>();
        plantInfoHandler = GetComponent<PlantInfoHandler>();
        plantSpawningHandler = GetComponent<PlantSpawningHandler>();
        colorHandler = GetComponent<ColorHandler>();
        soundHandler = GetComponent<SoundHandler>();
        particleHandler = GetComponent<ParticleHandler>();

        GetBagVariant();
        MakeBagUnusable();
    }

    // gets the "Carrot", "Wheat", etc. part from the gameobject name and assigns it to bagVariant
    private void GetBagVariant()
    {
        string[] _string = gameObject.name.Split(' ');
        bagVariant = _string[0];
    }

    //renders bag unusable on game start
    private void MakeBagUnusable()
    {
        timesUsed = maxTimesUsed;
        colorHandler.ChangeBagColor(timesUsed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        collisionChecker.CheckCollision(ref timesUsed, maxTimesUsed, ref tilledDirt, collision);
    }

    // initialized by the raycast check above
    public void InitializePlanting()
    {
        plantInfoHandler.InitializePlantInfo(tilledDirt, Wheat, Carrot);
        plantSpawningHandler.SpawnPlants(bagVariant, tilledDirt);
        colorHandler.ChangeBagColor(timesUsed);
        soundHandler.PlaySFX();
        particleHandler.EmitPlantingParticles(tilledDirt, plantParticles);
    }
}
