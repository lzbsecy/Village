using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseScript : MonoBehaviour
{

    public GameObject Camera;
    // Start is called before the first frame update
    void Start()
    {
        Camera = GameObject.Find("MainCamera");
        //Debug.Log(Screen.width + " " + Screen.height);
    }

    // Update is called once per frame
    void Update()
    {
        
 //      Debug.Log("相机："+Input.mousePosition.x + " " + Input.mousePosition.y);
 //      Debug.Log("世界：" + Camera.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition).x 
  //         + " " + Camera.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition).y);

        onClick();

    }

    void onClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
           
        }
    }
}
