using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{

    //how fast the projectile will travel
    public float speed;
    //how long the projectile will live
    public float lifetime;
    //how far the projectile will go
    public float distance;
    //what does the projectile consider a solid surface
    public LayerMask whatIsSolid;
    //the particle effect that will appear when the projectile is destroyed
    public GameObject destroyEffect;
    // Start is called before the first frame update

    protected virtual void Start()
    {
        Invoke("DestroyProjectile", lifetime);
    }

    // Update is called once per frame
   protected virtual void Update()
    {
        

    }

   protected private void DestroyProjectile()
    {
        //spawn the destroyed effect at this object's position at this object's rotation
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);

    }
}
