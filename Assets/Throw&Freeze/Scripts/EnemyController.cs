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
    public Material[] originalMaterials;
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
    [SerializeField][HideInInspector]
    private bool isFrozen;

    // Start is called before the first frame update

    
    void Start()
    {
        //get the skin mesh renderer in each child object
        skinMeshChildren = GetComponentsInChildren<Renderer>();
        //get the material that the gameObject started with
        
        /*NOTE"
         In order to get the original materials, the last child object in the heirarchy must have all 
         of the materials used on the gameObject.
         */
        GetOriginalMaterial();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision col)
    {
        //if this gameObject gets hit with an projectile with the tag called "IceProjectile"
        //and the bool isFrozen is not true
        if (col.gameObject.tag == "IceProjectile" && !isFrozen)
        {
            //player is frozen
            isFrozen = true;
            Debug.Log("Enemy is Frozen");
            //changes NPC material to ice
            ChangeMaterial(iceMaterial);
            //when enemy is hit by projectile, mineral count is reduced by 30% of current mineral count
            mineralCount = mineralCount - (int)(mineralCount * .3);
            //spawn the minerals
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
        {   //get the materials in the materials
            var mats = new Material[rend.materials.Length];
            //interate through the materials in the renderer
            for (int i = 0; i < rend.materials.Length; i++)
            {   //all the materials will be whatever the parameter is
                mats[i] = newMat;
            }
            rend.materials = mats;
        }
        //turn off the ice material in (unfrozenTimer) seconds
        StartCoroutine(ChangeBackMaterial(unfrozenTimer));
    }

    private void ChangeBackMaterial()
    {
        //foreach Renderer in the children
        foreach (Renderer rend in skinMeshChildren)
        {   //get the total number of materials for each Skin Mesh in the children
            //each material is reffered to as mats
            var mats = new Material[rend.materials.Length];
            //interate through each of the materials
            for (int i = 0; i < rend.materials.Length; i++)
            {
                mats[i] = rend.material;
            }
            // rend.materials = originalMaterials.ToArray();
            rend.materials = originalMaterials;
        }
    }

    private void GetOriginalMaterial()
    {
        //for each of the Renderer components in the children
        foreach (Renderer rend in skinMeshChildren)
        {   //get the total number of materials that is in the Skinned Mesh Renderer in the children
            //any material found in the children is going to be the orginal material that the gameobject started with
            for (int i = 0; i < rend.materials.Length; i++)
            {
                //THIS IS A VERY BRUTE FORCE APPLICATION
                //THIS WILL ONLY GET MATERIALS OF THE LAST CHILD GAMEOBJECT
                originalMaterials = rend.materials;

            }
        }
    }

    private IEnumerator ChangeBackMaterial(float waitTime)
    {
        //wait for waitTime seconds
        yield return new WaitForSeconds(waitTime);
        //change the player back to original material
        ChangeBackMaterial();
        //spawn the ice breaking effect at transform.up position, no rotation
        Instantiate(iceBreakEffect, transform.up, Quaternion.identity);
        //now that the player has changed back, the player is not frozen
        isFrozen = false;
        
    }


    private void SpawnMinerals()
    {
        //spawn 5 minerals 
        for (int i = 0; i< 5; i++)
        {   //instantiate the mineral prefabs at the gameObject's position with no rotation
            Instantiate(mineralPrefabs, transform.position, Quaternion.identity);
        }
        
    }

    /*PROGRAMMED AND COMMENTED BY NICHOLAS RAMSAY 
     * 
     *COPYRIGHT 2020, NICHOLAS RAMSAY, ALL RIGHTS RESERVED */
}
