using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ProjectileController : MonoBehaviour
{
    //how fast the projectile will travel
    public float speed;
    //how long the projectile will live
    public float lifetime;
    //current life counter
    public float _currentLifeSeconds;
    //how far the projectile will go
    public float distance;
    //what does the projectile consider a solid surface
    public LayerMask whatIsSolid;
    //the particle effect that will appear when the projectile is destroyed
    public GameObject destroyEffect;
    //rigidbody of gameobject 
    public Rigidbody _RIGID_BODY;
    //projectile collider
    public Collider projectileCollider;

    //Raycast for projectiles
    private RaycastHit hit;

    protected  void Start()
    {
         projectileCollider = GetComponent<Collider>();
        _RIGID_BODY = GetComponent<Rigidbody>();
        
    }

    //When the object has counted up to lifetime, destroy the projectile
   protected virtual void Update()
    {
        
        Invoke("DestroyProjectile", lifetime);

    }

   protected private void DestroyProjectile()
    {
        //spawn the destroyed effect at this object's position at this object's rotation
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    //if the projectile's collider enters a collider with the tag "Enemy"
    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            DestroyProjectile();
        }
        //if the layer is not equal to the current player then destroy the projectile
        if (whatIsSolid.value != 11)
        {
            DestroyProjectile();
        }
    }

    protected virtual void FixedUpdate()
    {
        //Add force to the rigid body of the projectile
        _RIGID_BODY.AddForce(transform.forward * speed);

      
    }

    /*PROGRAMMED AND COMMENTED BY NICHOLAS RAMSAY 
     * 
     *COPYRIGHT 2020, NICHOLAS RAMSAY, ALL RIGHTS RESERVED */

}
