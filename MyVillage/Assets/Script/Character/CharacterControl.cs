using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterControl : MonoBehaviour
{
    public float moveSpeed;
    public string state;
    public bool AI;

    Vector2 nextPosition;
    private string[] stateArr = new string[5] { "up", "down", "left", "right", "idle" };
    private float timeCount;
    // Start is called before the first frame update
    void Start()
    {
        timeCount = 0;
        state = "idle";
        nextPosition = GetComponent<Rigidbody2D>().position;
//        Debug.Log(GetComponent<BoxCollider2D>().bounds.size.x);
    }

    // Update is called once per frame
    void Update()
    {
        characterState();
        characterMove(state);
    }

    void characterState()
    {

        timeCount = timeCount + Time.deltaTime;
        if (AI == true)
        {
            if (timeCount >= 3)
            {
                timeCount = 0;
                switch (state)
                {
                    case "up":
                    case "down":
                    case "left":
                    case "right":
                        state = "idle";
                        break;
                    default:
                        state = stateArr[Random.Range(0, 4)];
                        break;
                }
            }
        }
        else
        {

            if (Input.GetKey(KeyCode.W))
            {
                state = "up";
            }
            else if (Input.GetKeyUp(KeyCode.W))
            {
                state = "idle";
            }

            if (Input.GetKey(KeyCode.S))
            {
                state = "down";
            }
            else if (Input.GetKeyUp(KeyCode.S))
            {
                state = "idle";
            }

            if (Input.GetKey(KeyCode.A))
            {
                state = "left";
            }
            else if (Input.GetKeyUp(KeyCode.A))
            {
                state = "idle";
            }

            if (Input.GetKey(KeyCode.D))
            {
                state = "right";
            }
            else if (Input.GetKeyUp(KeyCode.D))
            {
                state = "idle";
            }
        }
    }

    void characterMove(string state)
    {
        switch (state)
        {
            case "up":
                nextPosition = new Vector2(transform.position.x, transform.position.y+moveSpeed * Time.deltaTime );
                GetComponent<Rigidbody2D>().MovePosition(nextPosition);
                break;
            case "down":
                nextPosition = new Vector2(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime * -1);
                GetComponent<Rigidbody2D>().MovePosition(nextPosition);
                break;
            case "left":
                nextPosition = new Vector2(transform.position.x + moveSpeed * Time.deltaTime * -1, transform.position.y);
                GetComponent<Rigidbody2D>().MovePosition(nextPosition);   
                break;
            case "right":
                nextPosition = new Vector2(transform.position.x + moveSpeed * Time.deltaTime * 1, transform.position.y);
                GetComponent<Rigidbody2D>().MovePosition(nextPosition);
                break;
            default:
                break;  
        }

    }
}
