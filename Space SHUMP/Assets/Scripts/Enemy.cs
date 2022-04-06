/**** 
 * Created by: Akram Taghavi-Burris
 * Date Created: March 16, 2022
 * 
 * Last Edited by: Andrew Nguyen
 * Last Edited: April 6, 2022
 * 
 * Description: Enemy controler
****/

/*** Using Namespaces ***/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[SelectionBase] //forces selection of parent object
public class Enemy : MonoBehaviour
{
    /*** VARIABLES ***/

    [Header("Enemy Settings")]
    public float speed = 10f;
    public float fireRate = 0.3f;
    public float health = 10;
    public int score = 100;

    private BoundsCheck bndCheck; //reference to bounds check component
    
    //method that acts as a field (property)
    public Vector3 pos
    {
        get { return (this.transform.position); }
        set { this.transform.position = value; }
    }

    /*** MEHTODS ***/

    //Awake is called when the game loads (before Start).  Awake only once during the lifetime of the script instance.
    void Awake()
    {
        bndCheck = GetComponent<BoundsCheck>();
    }//end Awake()


    // Update is called once per frame
    void Update()
    {
        //Call the Move Method
        Move();

        //Check if bounds check exists and the object is off the bottom of the screne
        if(bndCheck != null && bndCheck.offDown)
        {
              Destroy(gameObject); //destory the object

        }//end if(bndCheck != null && !bndCheck.offDown)


    }//end Update()

    
    //Virtual methods can be overridden by child instances
    public virtual void Move()
    {
        Vector3 temPos = pos; //Temporary position
        temPos.y -= speed * Time.deltaTime; //Moving down
        pos = temPos; //Set position to the tempos

    } //end Move()

    private void OnCollisionEnter(Collision collision)
    {
        GameObject otherGO = collision.gameObject;

        if (otherGO.tag == "Projectile Hero")
        {
            Debug.Log("Enemy hit by projectile called " + otherGO.name);
            Destroy(otherGO); //Destroy the projectile
            GameManager.GM.UpdateScore(score); //Add to the score
            Destroy(gameObject); //Destroy the enemy
        }
        else //Projectile wasn't from player ship or something else
        {
            Debug.Log("Enemy was hit by a non-projectile");
        }
    } //end OnCollisionEnter()
}
