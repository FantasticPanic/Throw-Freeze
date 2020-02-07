using System.Collections;
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

    public GameObject mineralPrefabs;

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
    void Start()
    {
        //Decrease the mineral count over time
        StartCoroutine(DecreaseMineralOverTime());
    }

    // Update is called once per frame
    void Update()
    {
        //if player presses space or any button 
        if (isThrowing == false)
        {   //player left clicks
            if (Input.GetButtonDown("Fire1"))
            {   
                //player is throwing
                isThrowing = true;
            }
        }
        else
        {
            //player is not throwing
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
    {   //if isThrowing bool is true
        if (isThrowing == true)
        {
            //trigger the player Animator to play the throwing animation
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
        Instantiate(iceProjectile, projectileStartPoint.transform.position, fpsCam.transform.rotation);
       // Instantiate(iceProjectile, projectileStartPoint.transform.position, Quaternion.identity);
       
    }

    //decrease the player mineral by 1 every 2 seconds
    private IEnumerator DecreaseMineralOverTime()
    {   //if player mineral count is equal or larger than 0
        if (playerMineralCount >= 0)
        {      
            yield return new WaitForSeconds(2.0f);
            //decrease by 1 every 2 seconds
            playerMineralCount -= 1;
            //if player count is less than 0
            if (playerMineralCount < 0)
            {
                //just make the mineral count 0. No negatives
                playerMineralCount = 0;
                Debug.Log("Player is dead");
            }
        }
        //Loop the IEnumerator
        StartCoroutine(DecreaseMineralOverTime());
        Debug.Log(playerMineralCount);
    }

    //if the player walks into a trigger collider with the tag "Pickups"
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Pickups")
        {
            //increase by mineral count by 1
            playerMineralCount += 1;
        }
    }

}

    /*PROGRAMMED AND COMMENTED BY NICHOLAS RAMSAY 
     * 
     *COPYRIGHT 2020, NICHOLAS RAMSAY, ALL RIGHTS RESERVED */
