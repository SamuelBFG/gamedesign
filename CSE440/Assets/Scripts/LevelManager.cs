using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public GameObject currentCheckpoint;
    private PlayerController player;

    public GameObject deathParticle;
    public GameObject respawnParticle;
    public float respawnDelay;

    public int pointPenaltyOnDeath;

    public float gravityStore;

    private CameraController cam;

    public HealthManager healthManager;

    // Use this for initialization
    void Start() {
        player = FindObjectOfType<PlayerController>();
        cam = FindObjectOfType<CameraController>();
        healthManager = FindObjectOfType<HealthManager>();
    }

    // Update is called once per frame
    void Update() {

    }

    public void RespawnPlayer()
    {
        StartCoroutine("RespawnPlayerCo");
    }

    public IEnumerator RespawnPlayerCo()
    {   
        Instantiate(deathParticle, player.transform.position, player.transform.rotation);
        player.enabled = false;
        player.GetComponent<Renderer>().enabled = false;
        cam.isFollowing = false;
        gravityStore = player.GetComponent<Rigidbody2D>().gravityScale;
        player.GetComponent<Rigidbody2D>().gravityScale = 0f;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        ScoreManager.AddPoints(-pointPenaltyOnDeath);
        Debug.Log("Player Respawn");
        yield return new WaitForSeconds(respawnDelay);
        player.GetComponent<Rigidbody2D>().gravityScale = gravityStore;
        player.transform.position = currentCheckpoint.transform.position;
        player.knockBackCount = 0;
        player.GetComponent<Renderer>().enabled = true;
        player.enabled = true;
        cam.isFollowing = true;
        healthManager.FullHealth();
        healthManager.isDead = false;
        Instantiate(respawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);
    }
}
