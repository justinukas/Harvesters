using UnityEngine;

public class SeedBagManager : MonoBehaviour
{
    [HideInInspector] public int timesUsed;
    [HideInInspector] public int maxTimesUsed = 10000;
    [HideInInspector] public string bagVariant;
    [HideInInspector] public GameObject tilledDirt;
    [HideInInspector] public bool seedsDropping;

    [Header("Prefabs For Scripts")]
    [SerializeField] ParticleSystem plantParticles;
    [SerializeField] GameObject Wheat;
    [SerializeField] GameObject Carrot;
    [SerializeField] GameObject Pumpkin;

    private CollisionChecker collisionChecker;
    private PlantInfoHandler plantInfoHandler;
    private PlantSpawningHandler plantSpawningHandler;
    private ColorHandler colorHandler;
    private SoundHandler soundHandler;
    private ParticleHandler particleHandler;

    private readonly string[] plantVariants = { "Wheat", "Carrot", "Pumpkin" };

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
        string[] bagName = gameObject.name.Split(' ');
        bagVariant = bagName[0];
    }

    //renders bag unusable on game start
    private void MakeBagUnusable()
    {
        if (gameObject.CompareTag("UnboughtTool"))
        {
            timesUsed = maxTimesUsed;
            colorHandler.ChangeBagColor(timesUsed, maxTimesUsed);
        }
    }

    private void Update()
    {
        if (!gameObject.CompareTag("UnboughtTool"))
        {
            collisionChecker.CheckCollision(ref timesUsed, maxTimesUsed, ref tilledDirt, plantVariants, seedsDropping);
        }
    }

    // initialized by the collision check above
    public void InitializePlanting()
    {
        plantInfoHandler.InitializePlantInfo(tilledDirt, Wheat, Carrot, Pumpkin);
        plantSpawningHandler.SpawnPlants(bagVariant, tilledDirt);
        colorHandler.ChangeBagColor(timesUsed, maxTimesUsed);
        soundHandler.PlaySFX();
        particleHandler.EmitPlantingParticles(tilledDirt, plantParticles);
    }
}
