using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterState : MonoBehaviour
{

    private string stateName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        stateName = GetComponent<CharacterControl>().state;
        gameObject.GetComponent<Animator>().SetInteger("idle", 1);
        if (stateName=="up")
        {    
            gameObject.GetComponent<Animator>().SetInteger("up",1);
        }
        else if(stateName=="idle")
        {
            gameObject.GetComponent<Animator>().SetInteger("up", 0);
            gameObject.GetComponent<Animator>().SetInteger("idle", 0);
        }

        if (stateName == "down")
        {

            gameObject.GetComponent<Animator>().SetInteger("down", 1);
        }
        else if (stateName == "idle")
        {
            gameObject.GetComponent<Animator>().SetInteger("down", 0);
            gameObject.GetComponent<Animator>().SetInteger("idle", 0);
        }

        if (stateName == "left")
        {
            gameObject.GetComponent<Animator>().SetInteger("left", 1);
        }
        else if (stateName == "idle")
        {
            gameObject.GetComponent<Animator>().SetInteger("left", 0);
            gameObject.GetComponent<Animator>().SetInteger("idle", 0);
        }

        if (stateName == "right")
        {
            gameObject.GetComponent<Animator>().SetInteger("right", 1);
        }
        else if (stateName == "idle")
        {
            gameObject.GetComponent<Animator>().SetInteger("right", 0);
            gameObject.GetComponent<Animator>().SetInteger("idle", 0);
        }

    }
}
