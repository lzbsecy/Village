using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCollision : MonoBehaviour
{
    public GameObject mill;
    public GameObject text;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.collider.tag == "mill")
        {
            text.SetActive(true);
            text.GetComponent<Text>().text = "E → 耕种";
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "mill")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                collision.collider.GetComponent<MillController>().MillSwitch = true;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
