using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameManager gm;

    public float playerSpeed = 0.2f;

    float movementX;
    float movementY;

    public Vector3 origin;

    public float bulletReset;

    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    public MeshRenderer playerMR;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerMR = GetComponent<MeshRenderer>();

        origin = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gameState == 2) //Player is visible and has control
        {
            MovementInput();
            playerMR.enabled = true;
        }
        else //Player is invisible; no control
        {
            playerMR.enabled = false;
        }
    }

    void MovementInput()
    {
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && transform.position.y <= 6.2f)
        {
            movementY = playerSpeed;
        }
        else if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && transform.position.y >= -4.2f)
        {
            movementY = -playerSpeed;
        }
        else
        {
            movementY = 0;
        }
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && transform.position.x >= -9.6f)
        {
            movementX = -playerSpeed;
        }
        else if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && transform.position.x <= 9.6f)
        {
            movementX = playerSpeed;
        }
        else
        {
            movementX = 0;
        }

        transform.position += new Vector3(movementX, movementY, 0f);

        bulletReset++;

        if (Input.GetKeyDown(KeyCode.Space) && bulletReset >= 20)
        {
            Fire();
            bulletReset = 0;
        }
    }

    void Fire()
    {
        //Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        //Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = -bullet.transform.up * 8;

        //Destroy the bullet after 2 seconds
        Destroy(bullet, 2.0f);
    }
}
