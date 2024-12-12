using UnityEngine;

public class CollisionChecker : MonoBehaviour
{
    private SeedBagManager seedBagManager;

    private void Start()
    {
        seedBagManager = GetComponent<SeedBagManager>();
    }

    public void CheckCollision(ref int timesUsed, int maxTimesUsed, ref GameObject tilledDirt, string[] plantVariants, bool seedsDropping)
    {
        if (seedsDropping)
        {
            Vector3 bagPos = transform.position;

            if (Physics.SphereCast(bagPos, transform.localScale.x+0.4f, Vector3.down, out RaycastHit hit, 10))
            {
                GameObject hitObject = hit.collider.gameObject;
                if (hitObject.CompareTag("TilledDirt"))
                {
                    tilledDirt = hitObject;

                    ParentsEmptyOrNotCheck(ref timesUsed, maxTimesUsed, plantVariants, tilledDirt);
                }
            }
        }
    }

    private void ParentsEmptyOrNotCheck(ref int timesUsed, int maxTimesUsed, string[] plantVariants, GameObject tilledDirt)
    {
        if (timesUsed < maxTimesUsed)
        {
            bool allPlantParentsEmpty = true;

            foreach (string plant in plantVariants)
            {
                Transform plantParent = tilledDirt.transform.Find($"{plant}Parent");

                if (plantParent.childCount > 0)
                {
                    allPlantParentsEmpty = false;
                }
            }

            if (allPlantParentsEmpty)
            {
                timesUsed++;
                seedBagManager.InitializePlanting();
            }
        }
    }
}
