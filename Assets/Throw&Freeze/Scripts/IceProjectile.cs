using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceProjectile : ProjectileController
{
    public GameObject iceProjectile;
    private Rigidbody RIGID_BODY;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(PlayerController.PlayerInstance.transform.forward * speed * Time.deltaTime);
        if (speed != 0)
        {
            transform.position += PlayerController.PlayerInstance.fpsCam.transform.forward * (speed * Time.deltaTime);
        }
        base.Update();
        
    }

    void FixedUpdate()
    {
        //RIGID_BODY.AddForce(PlayerController.PlayerInstance.transform.forward * speed * Time.deltaTime);
    }

    /*PROGRAMMED AND COMMENTED BY NICHOLAS RAMSAY 
     * 
     *COPYRIGHT 2020, NICHOLAS RAMSAY, ALL RIGHTS RESERVED */
}


