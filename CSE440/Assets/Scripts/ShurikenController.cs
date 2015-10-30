using UnityEngine;
using System.Collections;

public class ShurikenController : MonoBehaviour {

    public float speed;
    //PlayerController player;

    public GameObject enemyDeathEffect;
    public GameObject impactEffect;

    //public int pointsForKill;

    public int damageToGive;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);

	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            other.GetComponent<EnemyHealthManager>().giveDamage(damageToGive);
        }

        if (other.name != "Player")
        {
            Instantiate(impactEffect, other.transform.position, other.transform.rotation);
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
