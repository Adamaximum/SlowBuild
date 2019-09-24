using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameManager gm;
    
    public int targetDest;

    public float targetY = -11.3f;
    public float targetZ = -5f;

    public float rotateX = -72f;
    public float adder;
    public float multiplier = 1;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        int randomNum = Random.Range(10, 20);
        targetDest = randomNum;
    }

    // Update is called once per frame
    void Update()
    {
        if(gm.astDest >= targetDest && gm.gameState == 2)
        {
            if(transform.position.y > targetY)
            {
                transform.position -= new Vector3(0f, 0.02f * multiplier, 0f);
            }
            if (transform.position.z < targetZ)
            {
                transform.position += new Vector3(0f, 0f, 0.01f * multiplier);
            }
            
            if (adder > rotateX)
            {
                float increase = -0.2f * multiplier;
                adder += increase;
                transform.Rotate(increase, 0f, 0f);

                gm.expansionPoint -= -0.1f * multiplier;
            }
        }
    }
}
