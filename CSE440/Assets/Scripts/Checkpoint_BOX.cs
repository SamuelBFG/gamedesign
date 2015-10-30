using UnityEngine;
using System.Collections;

public class Checkpoint_BOX : MonoBehaviour {

    public Sprite sprite;
    //public SpriteRenderer spriteRenderer;
    

	// Use this for initialization
	void Start () {
        //spriteRenderer = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            GetComponent<SpriteRenderer>().sprite = sprite;
        }
        //if (other.GetComponent<PlayerController>() == null)
        //    return;

        //Destroy(gameObject);
    }
}
