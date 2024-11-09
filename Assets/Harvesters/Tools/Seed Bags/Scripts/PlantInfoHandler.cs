using System.Collections.Generic;
using UnityEngine;

public class PlantInfoHandler : MonoBehaviour
{
    public Dictionary<string, (List<Vector3>, Transform, GameObject)> plantInfo;

    public void InitializePlantInfo(GameObject tilledDirt, GameObject Wheat, GameObject Carrot, GameObject Pumpkin)
    {
        List<Vector3> wheatPositionsList = PlantPositions.wheatPositionsList;
        List<Vector3> carrotPositionsList = PlantPositions.carrotPositionsList;
        List<Vector3> pumpkinPositionsList = PlantPositions.pumpkinPositionsList;

        Transform WheatParent = tilledDirt.transform.Find("WheatParent");
        Transform CarrotParent = tilledDirt.transform.Find("CarrotParent");
        Transform PumpkinParent = tilledDirt.transform.Find("PumpkinParent");

        plantInfo = new Dictionary<string, (List<Vector3>, Transform, GameObject)>
        {
            {"Wheat", (wheatPositionsList, WheatParent, Wheat)},
            {"Carrot", (carrotPositionsList, CarrotParent, Carrot)},
            {"Pumpkin", (pumpkinPositionsList, PumpkinParent, Pumpkin)}
        };
    }
}
