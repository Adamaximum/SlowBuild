using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidControl : MonoBehaviour {

    public GameManager gm;
    public PlayerControl player;

    //public AudioSource astExpSnd;

    public GameObject explosionPrefab;
    public GameObject shipExpPrefab;
    
	// Use this for initialization
	void Start () {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GameObject.Find("Player").GetComponent<PlayerControl>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //Assigns explosion animation to player and ends the game
            gm.gameState = 3;
            GameObject shipExp = Instantiate(shipExpPrefab);
            shipExp.transform.position = player.transform.position;
        }

        if(collision.gameObject.tag == "Bullet")
        {
            //Assigns explosion animation to an asteroid and destroys it
            GameObject explosion = Instantiate(explosionPrefab);
            explosion.transform.position = transform.position;

            int index = gm.asteroids.IndexOf(gameObject);
            gm.asteroids.Remove(gameObject);
            gm.astSpeed.RemoveAt(index);
            gm.astArt.RemoveAt(index);
            Debug.Log("Destroying Asteroid");

            Destroy(gameObject);
            Destroy(collision.gameObject);

            gm.astDest++;

        }
    }
}
