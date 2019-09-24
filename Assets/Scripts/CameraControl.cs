using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameManager gm;

    public float targetDest;

    public float targetY = -11.3f;
    public float targetZ = -5f;

    public float rotateX = -72f;
    public float adder;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gm.astDest >= targetDest)
        {
            if(transform.position.y > targetY)
            {
                transform.position -= new Vector3(0f, 0.02f, 0f);
            }
            if (transform.position.z < targetZ)
            {
                transform.position += new Vector3(0f, 0f, 0.01f);
            }
            
            if (adder > rotateX)
            {
                adder -= 0.1f;
                transform.Rotate(-0.1f, 0f, 0f);
            }
            
        }
    }
}
