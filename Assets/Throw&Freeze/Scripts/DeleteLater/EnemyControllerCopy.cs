using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerCopy : MonoBehaviour
{

    //variable for the Renderer array
    [SerializeField]
    private Renderer[] skinMeshChildren;
    //variable for the original materials
    [SerializeField]
    //private Material[] originalMaterials;
    public List<Material> originalMaterials = new List<Material>();

    // Start is called before the first frame update 
    void Start()
    {
        
        //get the renderer components of this gameobject's children
        skinMeshChildren = GetComponentsInChildren<Renderer>();
        //upon starting the scene, get the game object's materials that it started with
        GetOriginalMaterial();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GetOriginalMaterial()
    {
        //for each of the Renderer components in the children
        foreach (Renderer rend in skinMeshChildren)
        {   
            //get the total number of materials that is in the Skinned Mesh Renderer in the children
            //any material found in the children is going to be the orginal material that the gameobject started with
            for (int i = 0; i < rend.materials.Length; i++)
            {
                //originalMaterials = rend.materials;
                originalMaterials.AddRange(rend.materials);
            }

        }
    }

   
}
