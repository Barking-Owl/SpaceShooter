/**** 
 * Created by: Andrew Nguyen
 * Date Created: April 11, 2022
 * 
 * Last Edited by: Andrew Nguyen
 * Last Edited: April 11, 2022
 * 
 * Description: Scrolls the background
****/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialScroller : MonoBehaviour
{
    //VARIABLES//
    public Vector2 scrollSpeed = new Vector2(0, 0f);

    private Renderer goRenderer; //Render component
    private Material goMat; //Game object material

    private Vector2 offset;
        
    // Start is called before the first frame update
    void Start()
    {
        goRenderer = GetComponent<Renderer>();
        goMat = goRenderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        offset = (scrollSpeed * Time.deltaTime); //Set offset value over time
        goMat.mainTextureOffset += offset; //Set texture offset
    } //end Update()
}
