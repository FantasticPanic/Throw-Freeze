using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{

    private ParticleSystem ps;
    public float particleDuration;
   
    
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {

        //at some point the partcile stops playing
        //when that happens, destroy it
        StartCoroutine(DestroyParticles(particleDuration));
       
        
    }
    //destroy the particles after they have been spawned for waitTime seconds
    private IEnumerator DestroyParticles(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(this.gameObject);


    }

    /*PROGRAMMED AND COMMENTED BY NICHOLAS RAMSAY 
     * 
     *COPYRIGHT 2020, NICHOLAS RAMSAY, ALL RIGHTS RESERVED */
}
