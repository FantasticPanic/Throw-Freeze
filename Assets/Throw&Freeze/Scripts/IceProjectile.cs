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
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(PlayerController.PlayerInstance.transform.forward * speed * Time.deltaTime);
        base.Update();
        
    }
}


