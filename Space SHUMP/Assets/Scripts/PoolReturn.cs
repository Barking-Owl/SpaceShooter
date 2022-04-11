/**** 
 * Created by: Andrew Nguyen
 * Date Created: April 11, 2022
 * 
 * Last Edited by: Andrew Nguyen
 * Last Edited: April 11, 2022
 * 
 * Description: Returns objects back to an objectpool.
****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolReturn : MonoBehaviour
{

    private ObjectPool pool; //reference to pool

    // Start is called before the first frame update
    void Start()
    {
        pool = ObjectPool.POOL; //find the object pool, one per level
    } //end Start()

    //This class mainly manages when an object should return back to the pool.
    private void OnDisable()
    {
        //Check pool is empty
        if (pool != null)
        {
            pool.ReturnObject(this.gameObject);
        } //end if
    } //end OnDisable()


}
