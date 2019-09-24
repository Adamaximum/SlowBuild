using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour
{
    public GameManager gm;
    public CameraControl cc;

    public AudioSource Layer3;
    public AudioSource Layer4;
    public AudioSource Layer5;
    public AudioSource Layer6;

    // Use this for initialization
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        cc = GameObject.Find("Main Camera").GetComponent<CameraControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gameState > 1)
        {
            Layer3.volume += 0.01f;
        }
        if (gm.astDest >= 10)
        {
            Layer4.volume += 0.01f;
        }
        if (gm.astDest >= cc.targetDest)
        {
            Layer5.volume += 0.01f;
        }
        if (cc.adder < cc.rotateX)
        {
            Layer6.volume += 0.01f;
        }
    }
}
