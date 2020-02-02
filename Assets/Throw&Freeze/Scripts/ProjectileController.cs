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
    // Start is called before the first frame update

    protected virtual void Start()
    {
        _currentLifeSeconds = 0;
    }

    // Update is called once per frame
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

}
