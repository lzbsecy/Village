using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float MoveSpeed;
    public float limitSpeed;

    Vector3 position = new Vector3(Screen.width / 2.0f, Screen.height / 2.0f, 0.0f);
    Ray ray;
    RaycastHit hit;

    public bool isFollow=true;
    public GameObject player;
    public Vector3 FollowDistance  = new Vector3(6, 3, 0);
    Vector3 moveDir = new Vector3(0,0,0);
    Vector3 PlayerPosition;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        MoveSpeed = player.GetComponent<CharacterControl>().moveSpeed;
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray();
        if(GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControl>().state=="idle")
        {
            isFollow = false;
        }
        else
        {
            isFollow = true;
        }

        if (isFollow == true)
        {
            if((PlayerPosition-transform.position).magnitude>15)
            {
                MoveSpeed = limitSpeed;
            }
            else
            {
                MoveSpeed = player.GetComponent<CharacterControl>().moveSpeed;
            }

            Follow();
        }
        else
        {
            MouseDistanceTirgger();
        }

    }


    void Follow()
    {
        PlayerPosition = player.transform.position;
 
        if (Mathf.Abs(PlayerPosition.x - transform.position.x) >= FollowDistance.x)
        {
            moveDir.x = Mathf.Sign(PlayerPosition.x - transform.position.x);
            transform.Translate(new Vector3(MoveSpeed * Time.deltaTime * moveDir.x, 0, 0), Space.World);
        }
        if (Mathf.Abs(PlayerPosition.y - transform.position.y) >= FollowDistance.y)
        {
            moveDir.y = Mathf.Sign(PlayerPosition.y - transform.position.y);
            transform.Translate(new Vector3(0, MoveSpeed * Time.deltaTime * moveDir.y, 0), Space.World);
        }

    }

    void MouseDistanceTirgger()
    {

        if (Input.mousePosition.x < 10)
        {
            transform.Translate(new Vector3(MoveSpeed * 5 * Time.deltaTime * -1, 0, 0), Space.World);
        }
        if(Input.mousePosition.x > Screen.width-10)
        {
            transform.Translate(new Vector3(MoveSpeed * 5 * Time.deltaTime * 1, 0, 0), Space.World);
        }
        if (Input.mousePosition.y < 10)
        {
            transform.Translate( new Vector3(0, MoveSpeed * 5 * Time.deltaTime * -1, 0), Space.World);
        }
        if (Input.mousePosition.y > Screen.height-10)
        {
            transform.Translate(new Vector3(0, MoveSpeed * 5 * Time.deltaTime * 1, 0), Space.World);
        }

    }

    void Ray()
    {
        int radius = 3;
        Collider[] cols = Physics.OverlapSphere(this.transform.position, radius, LayerMask.NameToLayer("layername"));
        if (cols.Length > 0)
        {
            for (int i = 0; i < cols.Length; i++)
            {
                Debug.Log("检测到物体" + cols[i].name);
            }
        }


    }
}
