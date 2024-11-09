using System;
using UnityEngine;

public class CollisionChecker : MonoBehaviour
{
    private SeedBagManager seedBagManager;

    private void Start()
    {
        seedBagManager = GetComponent<SeedBagManager>();
    }

    public void CheckCollision(ref int timesUsed, int maxTimesUsed, ref GameObject tilledDirt, Collision collision, string[] plantVariants)
    {
        if (collision.gameObject.CompareTag("TilledDirt"))
        {
            tilledDirt = collision.gameObject;

            if (timesUsed < maxTimesUsed)
            {
                bool allEmpty = true;

                foreach (string plant in plantVariants)
                {
                    Transform plantParent = tilledDirt.transform.Find($"{plant}Parent");

                    if (plantParent.childCount > 0)
                    {
                        allEmpty = false;
                    }
                }

                if (allEmpty)
                {
                    timesUsed++;
                    seedBagManager.InitializePlanting();
                }
            }
        }
    }
}
