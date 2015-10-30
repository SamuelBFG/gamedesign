using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour {

    public LevelManager levelManager;
    public PlayerController player;


	// Use this for initialization
	void Start () {
        levelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            if (gameObject.name == "Screw")
            {
                levelManager.respawnDelay = 0f;
                levelManager.RespawnPlayer();
                levelManager.respawnDelay = 1f;
            }

            else
            {
                levelManager.RespawnPlayer();
                levelManager.respawnDelay = 1f;
            } 


            }
    }
    
}
