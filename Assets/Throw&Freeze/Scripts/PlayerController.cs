using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator playerAnim;
    public GameObject iceProjectile;
    public GameObject playerHand;

    public float throwRate;

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
        if (Input.GetButtonDown("Submit"))
        {
            isThrowing = true;
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
            StartCoroutine(ThrowTimer(throwRate));
        }
        else
        {
            playerAnim.SetBool("isThrowing", false);
        }
    }

    private IEnumerator ThrowTimer(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        var newProjectile =  Instantiate(iceProjectile, playerHand.transform.position, Quaternion.identity);
        Rigidbody iceProjectileRB = iceProjectile.GetComponent<Rigidbody>();

        iceProjectileRB.AddForce(gameObject.transform.forward * 100);
    }
}
