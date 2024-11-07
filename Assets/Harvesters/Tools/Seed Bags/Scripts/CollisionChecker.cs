using UnityEngine;

public class CollisionChecker : MonoBehaviour
{
    private SeedBagManager seedBagManager;

    private void Start()
    {
        seedBagManager = GetComponent<SeedBagManager>();
    }

    public void CheckCollision(ref int timesUsed, int maxTimesUsed, ref GameObject tilledDirt, Collision collision)
    {
        if (collision.gameObject.CompareTag("TilledDirt"))
        {
            tilledDirt = collision.gameObject;

            if (timesUsed < maxTimesUsed && tilledDirt.transform.Find("CarrotParent").childCount == 0 && tilledDirt.transform.Find("WheatParent").childCount == 0)
            {
                timesUsed++;
                seedBagManager.InitializePlanting();
            }
        }
    }
}
