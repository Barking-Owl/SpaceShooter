/**** 
 * Created by: Andrew Nguyen
 * Date Created: April 4, 2022
 * 
 * Last Edited by: Andrew Nguyen
 * Last Edited: April 4, 2022
 * 
 * Description: Spawns enemies
****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    /***VARIABLES***/
    [Header("Enemy Settings")]
    public GameObject[] prefabEnemies; //all enemies that can spawn
    public float enemySpawnPerSecond; //how many enemies spawn per second
    public float enemyDefaultPadding; //padding position

    private BoundsCheck bndCheck; //Reference bound check component

    // Start is called before the first frame update
    void Start()
    {
        bndCheck = GetComponent<BoundsCheck>();
        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond); //After a time delay spawn enemies. Time delay for this invocation is enemySpawnPerSecond / 1f
    } //end Start()

    void SpawnEnemy()
    {
        //Choose a random enemy prefab
        int idx = Random.Range(0, prefabEnemies.Length);
        //Random range will never select the max value

        GameObject go = Instantiate<GameObject>(prefabEnemies[idx]);

        //Place enemy
        float enemyPadding = enemyDefaultPadding;

        if (go.GetComponent<BoundsCheck>() != null) { enemyPadding = Mathf.Abs(go.GetComponent<BoundsCheck>().radius); }

        //Then set position
        Vector3 pos = Vector3.zero;
        float xMin = -bndCheck.camWidth + enemyPadding;
        float xMax = bndCheck.camWidth - enemyPadding;
        pos.x = Random.Range(xMin, xMax); 
        pos.y = bndCheck.camHeight + enemyPadding; //Height + padding

        go.transform.position = pos;

        //Then invoke again

        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond);

    } //end SpawnEnemy()

    // Update is called once per frame
    void Update()
    {
        
    } //end Update()
}
