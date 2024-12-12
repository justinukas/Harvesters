using System.Collections.Generic;
using UnityEngine;

public class findmaterialobjects : MonoBehaviour
{
    public List<GameObject> objects;

    [SerializeField] Material material;

    private void Start()
    {
        GameObject[] AllObjs = Object.FindObjectsByType<GameObject>(FindObjectsSortMode.None);
        foreach (GameObject Obj in AllObjs)
        {
            if (Obj.activeInHierarchy)
            {
                if (Obj.GetComponent<Renderer>())
                {
                    foreach (Material Mat in Obj.GetComponent<Renderer>().sharedMaterials)
                    {
                        if (Mat == material)
                        {
                            objects.Add(Obj);
                        }
                    }
                }
            }
        }

        foreach (GameObject obj in objects)
        {
            Debug.Log(obj);
        }
    }
}
