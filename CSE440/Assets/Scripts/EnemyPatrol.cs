using UnityEngine;
using System.Collections;

public class EnemyPatrol : MonoBehaviour {


    public float moveSpeed;
    public bool moveRight;

    public Transform wallCheck;
    public float wallCheckRadius;
    public LayerMask whatIsWall;
    private bool hittingWall;
    private bool notAtEdge;
    public Transform edgeCheck;

    public Vector3 enemyScale;

    // Use this for initialization
    void Start () {
        enemyScale = transform.localScale;

	}
	
	// Update is called once per frame
	void Update () {
        hittingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);

        notAtEdge = Physics2D.OverlapCircle(edgeCheck.position, wallCheckRadius, whatIsWall);

        if (hittingWall || !notAtEdge)
            moveRight = !moveRight;

        if (moveRight)
        {
            transform.localScale = new Vector3(-enemyScale.x, enemyScale.y, enemyScale.z);
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            transform.localScale = new Vector3(enemyScale.x, enemyScale.y, enemyScale.z);
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
    }   
}
