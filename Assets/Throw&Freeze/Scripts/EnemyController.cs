using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //enemy's collider
    public Collider enemyCollider;
    //enemy original material
    [SerializeField]
    private Renderer[] originalMaterial;
    //frozen material
    public Material iceMaterial;

    // Start is called before the first frame update
    void Start()
    {
        enemyCollider = GetComponent<Collider>();
        originalMaterial = GetComponentsInChildren<Renderer>();
       
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
            ChangeMaterial(iceMaterial);
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
    }
}
