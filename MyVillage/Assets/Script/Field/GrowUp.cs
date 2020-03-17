using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowUp : MonoBehaviour
{
    public bool growSwitch = false;
    public float GrowthTime;
    public float fieldState;
    public Sprite field1;
    public Sprite field2;
    public Sprite field3;
    public Sprite field4;

    private float timeCount;

    private bool isFarm;
    
    // Start is called before the first frame update
    void Start()
    {
        GrowthTime = 5;
        timeCount = 0;
        fieldState = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(growSwitch==true)
        {
            grow();
        }
    }


    void grow()
    {
        timeCount += (float)Time.deltaTime;
        if (fieldState < 5)
        {
            if (timeCount >= GrowthTime)
            {
                timeCount = 0;
                fieldState++;
                switch (fieldState)
                {
                    case 1:
                        gameObject.GetComponent<SpriteRenderer>().sprite = field1;
                        break;
                    case 2:
                        gameObject.GetComponent<SpriteRenderer>().sprite = field2;
                        break;
                    case 3:
                        gameObject.GetComponent<SpriteRenderer>().sprite = field3;
                        break;
                    case 4:
                        gameObject.GetComponent<SpriteRenderer>().sprite = field4;
                        break;
                }
            }
        }
    }
}
