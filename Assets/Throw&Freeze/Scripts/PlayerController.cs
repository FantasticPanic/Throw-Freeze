﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    [SerializeField]
    private int playerMineralCount = 100;
    //first person camera
    public Camera fpsCam;
    //TextMesh for mineralCOunt
    public TextMeshProUGUI mineralCountText;

    //TextMesh for mineral decrease timer
    public TextMeshProUGUI mineralDecreaseText;

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
        StartCoroutine(DecreaseMineralOverTime());
    }

    // Update is called once per frame
    void Update()
    {
        //if player presses space or any button 
        if (isThrowing == false)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                isThrowing = true;
            }
        }
        else
        {
            isThrowing = false;
        }
        Throw();
        mineralCountText.text = "Mineral Count : " + playerMineralCount;

        //the maximum minerals a player can have is 100
        if (playerMineralCount > 100)
        {
            playerMineralCount = 100;
        }
        
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
    
    //spawn the ice projectile when the player presses the throw button
    //THIS IS AN ANIMATION EVENT
    public void AnimationThrow()
    {
         //spawn an iceProjectile at a Transform start posision
         //no rotation
        Instantiate(iceProjectile, projectileStartPoint.transform.position, Quaternion.identity);
       // Instantiate(iceProjectile, projectileStartPoint.transform.position, Quaternion.identity);
       
    }

    //decrease the player mineral by 1 every 2 seconds
    private IEnumerator DecreaseMineralOverTime()
    {
        if (playerMineralCount > 0)
        {
            
            yield return new WaitForSeconds(2.0f);
            playerMineralCount -= 1;
        }
        StartCoroutine(DecreaseMineralOverTime());
        Debug.Log(playerMineralCount);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Pickups")
        {
            playerMineralCount += 1;
        }
    }

    /*PROGRAMMED AND COMMENTED BY NICHOLAS RAMSAY 
     * 
     *COPYRIGHT 2020, NICHOLAS RAMSAY, ALL RIGHTS RESERVED */
}
