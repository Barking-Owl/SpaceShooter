/**** 
 * Created by: Andrew Nguyen
 * Date Created: April 6, 2022
 * 
 * Last Edited by: Andrew Nguyen
 * Last Edited: April 11, 2022
 * 
 * Description: Create a pool of objects for reuse. Instantiate/destroying can be very resource intensive
****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    //VARIABLES//
    static public ObjectPool POOL;

    #region ObjectPool Singleton
    void CheckPoolIsInScene()
    {
        if(POOL == null)
        {
            POOL = this;
        } //end if
        else
        {
            Debug.LogError("POOL.Awake() - Attempted to assign a second ObjectPOOL.POOL");
        } //end else
    } //end CheckPoolIsInScene()
    #endregion

    private Queue<GameObject> projectiles = new Queue<GameObject>(); //New queue of Projectiles

    [Header("Pool Settings")]
    public GameObject projectilePrefab;
    public int poolStartSize = 5;

    //METHODS//

    private void Awake()
    {
        CheckPoolIsInScene(); //Check if a singleton POOL already exists
    } //end Awake()

    // Start is called before the first frame update
    void Start()
    {
        //First instantiate the pool
        for (int i = 0; i < poolStartSize; i++)
        {
            GameObject projectileGO = Instantiate(projectilePrefab);
            projectiles.Enqueue(projectileGO);
            projectileGO.SetActive(false); //Disabled in scene
        } //end for loop
    } //end Start()

    public GameObject GetObject()
    {
        if(projectiles.Count > 0)
        {
            GameObject gObject = projectiles.Dequeue(); //Take the first object in line
            gObject.SetActive(true);
            return gObject;
        }
        else
        {
            Debug.LogWarning("Out of objects; reloading...");
            return null;
        }
    } //end GetObject()

    public void ReturnObject(GameObject gObj)
    {
        projectiles.Enqueue(gObj);
        gObj.SetActive(false);
    } //end ReturnObject()

    // Update is called once per frame
    void Update()
    {
        
    } //end Update()
}
