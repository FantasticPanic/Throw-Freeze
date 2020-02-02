using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //animator for the player
    public Animator playerAnim;
    //the gameobject that will be the ice projectile
    public GameObject iceProjectile;
    //the point at which the projectile will start
    public GameObject projectileStartPoint;
    //boolean value for the throwing animation
    [SerializeField]
    private bool isThrowing;

    private static PlayerController playerInstance;
    //allows us to reference the playerInstance in other scripts
    public static PlayerController PlayerInstance
    {
        get
        {
            //if instance does not exist
            if (playerInstance == null)
            {
                //find the PlayerController and make a reference to it
                playerInstance = FindObjectOfType<PlayerController>();
            }

            return playerInstance;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if player presses space or any button 
        if (isThrowing == false)
        {
            if (Input.GetButtonDown("Submit"))
            {
                isThrowing = true;
            }
        }
        else
        {
            isThrowing = false;
        }
        Throw();
    }

    private void Throw()
    {
        if (isThrowing == true)
        {
            playerAnim.SetBool("isThrowing", true);
        }
        else
        {
            playerAnim.SetBool("isThrowing", false);
        }
    }

    public void AnimationEnded()
    {
        isThrowing = false;
    }

    public void AnimationThrow()
    {
        Instantiate(iceProjectile, projectileStartPoint.transform.position, Quaternion.identity);
    }
}
