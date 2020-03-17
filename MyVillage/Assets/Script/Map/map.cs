using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class map : MonoBehaviour
{

    public GameObject tree1;
    public GameObject tree0;
    public GameObject field0;
    public GameObject mill;
    public GameObject player;

    Vector2 position;
    // Start is called before the first frame update
    void Start()
    {

        position = GameObject.Find("zero").transform.position;
        TextAsset mapTxt = Resources.Load("mapFile") as TextAsset;
        string[] strs = mapTxt.text.Split('\n');
        foreach(string str in strs)
        {
            string[] s = str.Split('-');
            foreach(string i in s)
            {
                position.x = position.x + player.GetComponent<SpriteRenderer>().bounds.size.x / 1.5f;

                switch (i)
                {
                    case "1":
                        if (randomNum(0, 1) == 0)
                        {
                            Instantiate(tree0, position, transform.rotation);
                        }
                        else
                        {
                            Instantiate(tree1, position, transform.rotation);
                        }
                        break;
                    case "2":
                        Instantiate(field0, position, transform.rotation);
                        break;
                    case "3":
                        Instantiate(mill, position, transform.rotation);
                        break;
                    default:
                        break;
                }
               
            }
            position.x = GameObject.Find("zero").transform.position.x;
            position.y = position.y - player.GetComponent<SpriteRenderer>().bounds.size.y / 2.3f;
        }
    }

    // Update is called once per frame
    void Update()
    {


    }

    int randomNum(int minNum,int maxNum)
    {
        return Random.Range(minNum, maxNum + 1);
    }

}
