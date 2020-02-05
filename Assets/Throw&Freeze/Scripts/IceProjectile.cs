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
        //transform.Translate(PlayerController.PlayerInstance.transform.forward * speed * Time.deltaTime);
        if (speed != 0)
        {
            //transform.position += PlayerController.PlayerInstance.fpsCam.transform.forward * (speed * Time.deltaTime);
           // RIGID_BODY.AddForce(PlayerController.PlayerInstance.fpsCam.transform.forward * 7.0f);
        }
        base.Update();
        
    }

    void FixedUpdate()
    {
        //RIGID_BODY.AddForce(PlayerController.PlayerInstance.transform.forward * speed * Time.deltaTime);
        // RIGID_BODY.AddForce(PlayerController.PlayerInstance.fpsCam.transform.forward * speed);
        base.FixedUpdate();
    }

    /*PROGRAMMED AND COMMENTED BY NICHOLAS RAMSAY 
     * 
     *COPYRIGHT 2020, NICHOLAS RAMSAY, ALL RIGHTS RESERVED */
}


