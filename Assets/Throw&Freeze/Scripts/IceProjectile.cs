using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceProjectile : ProjectileController
{
    //public GameObject iceProjectile;
    private Rigidbody RIGID_BODY;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        RIGID_BODY = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
     
        base.Update();
        
    }

    void FixedUpdate()
    {
        // RIGID_BODY.AddForce(PlayerController.PlayerInstance.fpsCam.transform.forward * speed);
        base.FixedUpdate();
    }

    /*PROGRAMMED AND COMMENTED BY NICHOLAS RAMSAY 
     * 
     *COPYRIGHT 2020, NICHOLAS RAMSAY, ALL RIGHTS RESERVED */
}


