using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    /*PROGRAMMED AND COMMENTED BY NICHOLAS RAMSAY*/
    //enemy's collider
    public Collider enemyCollider;
    //enemy original material
    [SerializeField]
    private Renderer[] skinMeshChildren;
    //get a list of the original materials that the gameObject started with
    public Material[] ogMats;
    //frozen material
    public Material iceMaterial;
    //mineral count for enemy
    [SerializeField]
    private int mineralCount = 100;
    //variable for mineral prefab
    public GameObject mineralPrefabs;
    //enemy will be unfrozen when this timer is over
    public float unfrozenTimer = 5f;
    //ice break effect when unfrozerTimer hits zero
    public GameObject iceBreakEffect;
    //minerals thatt fall from hit enemy
    public GameObject minerals;

    // Start is called before the first frame update

    
    void Start()
    {
        //get the collider component
        enemyCollider = GetComponent<Collider>();
        //get the renderer components of this gameobject's children
        skinMeshChildren = GetComponentsInChildren<Renderer>();
        GetOriginalMaterial();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "IceProjectile")

        {
            Debug.Log("Enemy is Frozen");
            //changes NPC material to ice
            ChangeMaterial(iceMaterial);
            //when enemy is hit by projectile, mineral count is reduced by 30% of current mineral count
            mineralCount = mineralCount - (int)(mineralCount * .3);
            SpawnMinerals();
        }

    }



    private void ChangeMaterial(Material newMat)
    {
        //renderer array is children
        Renderer[] children;
        //the children is an array of the renderer components in gameobject's children
        children = GetComponentsInChildren<Renderer>();
        //foreach Renderer in the children
        foreach (Renderer rend in children)
        {   //get the materials in the mats
            var mats = new Material[rend.materials.Length];
            for (int i = 0; i < rend.materials.Length; i++)
            {
                mats[i] = newMat;
            }
            rend.materials = mats;
        }
        StartCoroutine(ChangeBackMaterial(unfrozenTimer));
    }

    private void ChangeBackMaterial()
    {
        //renderer array is children
        //Renderer[] children;
        //the children is an array of the renderer components in gameobject's children
        //children = GetComponentsInChildren<Renderer>();
        //foreach Renderer in the children
        foreach (Renderer rend in skinMeshChildren)
        {   //get the total number of materials for each Skin Mesh in the children
            // each material is reffered to as mats
            var mats = new Material[rend.materials.Length];
            //interate through each of the materials
            for (int i = 0; i < rend.materials.Length; i++)
            {
                mats[i] = rend.material;
            }
            // rend.materials = originalMaterials.ToArray();
            rend.materials = ogMats;
        }
    }

    private void GetOriginalMaterial()
    {
        //create a Renderer array variable
        Renderer[] skinMeshChildren;
        //get the Renderer component from each child 
        skinMeshChildren = GetComponentsInChildren<Renderer>();
        //for each of the Renderer components in the children
        foreach (Renderer rend in skinMeshChildren)
        {   //get the total number of materials that is in the Skinned Mesh Renderer in the children
            //any material found in the children is going to be the orginal material that the gameobject started with
            for (int i = 0; i < rend.materials.Length; i++)
            {
                //THIS IS A VERY BRUTE FORCE APPLICATION
                //THIS WILL ONLY GET MATERIALS OF THE LAST CHILD GAMEOBJECT
                ogMats = rend.materials;

            }
        }
    }

    private IEnumerator ChangeBackMaterial(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        ChangeBackMaterial();
        Instantiate(iceBreakEffect, transform.position, Quaternion.identity);
        
    }


    private void SpawnMinerals()
    {
        for (int i = 0; i< 5; i++)
        {
            Instantiate(minerals, Vector3.zero, Quaternion.identity);
        }
        
    }

    /*PROGRAMMED AND COMMENTED BY NICHOLAS RAMSAY 
     * 
     *COPYRIGHT 2020, NICHOLAS RAMSAY, ALL RIGHTS RESERVED */
}
