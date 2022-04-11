/**** 
 * Created by: Andrew Nguyen
 * Date Created: April 6, 2022
 * 
 * Last Edited by: Andrew Nguyen
 * Last Edited: April 11, 2022
 * 
 * Description: Decides and manages projectile boundaries
****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //Variables
    private BoundsCheck bndCheck; //Reference to boundaary

    private void Awake()
    {
        bndCheck = GetComponent<BoundsCheck>();

    }//end Awake()

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Check if its gone offscreen
        if (bndCheck.offUp)
        {
            //Destroy(gameObject);
            gameObject.SetActive(false); 
            bndCheck.offUp = false; //Reset things

        }//end if

    } //end Update()
}
