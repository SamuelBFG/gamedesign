using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private float moveVelocity;
    public float JumpHeight;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;

    private bool doubleJumped;
    public bool lookingRight = true;

    private Animator anim;

    public Transform rightFirePoint;
    public Transform leftFirePoint;

    public GameObject rightShuriken;
    public GameObject leftShuriken;

    public float shotDelay;
    private float shotDelayCounter;

    public float knockBack;
    public float knockBackLength;
    public float knockBackCount;
    public bool knockFromRight;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }


    // Update is called once per frame
    void Update()
    {

        if (grounded)
            doubleJumped = false;

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.Space) && !doubleJumped && !grounded)
        {
            Jump();
            doubleJumped = true;
        }

        moveVelocity = 0f;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            anim.SetInteger("Right", 0);
            moveVelocity = -moveSpeed;
            lookingRight = false;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetInteger("Right", 1);
            moveVelocity = moveSpeed;
            lookingRight = true;
        }

        if(knockBackCount <= 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            if (knockFromRight)
                GetComponent<Rigidbody2D>().velocity = new Vector2(-knockBack, knockBack);
            if(!knockFromRight)
                GetComponent<Rigidbody2D>().velocity = new Vector2(knockBack, knockBack);
            knockBackCount -= Time.deltaTime;
        }

        var flag = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow);
        // A ? B : C
        //It turns to be B when A is true
        //Otherwise C.
        // A ?? B
        //It turns to be A if A is not null.
        //Otherwise B
        //anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
        anim.SetFloat("Speed", flag ? GetComponent<Rigidbody2D>().velocity.x : 0);

        if (Input.GetKey(KeyCode.X))
        {
            shotDelayCounter -= Time.deltaTime;

            if(shotDelayCounter <= 0 && lookingRight == true) 
            {
                Instantiate(rightShuriken, rightFirePoint.position, rightFirePoint.rotation);
                shotDelayCounter = shotDelay;
            }

            else if(shotDelayCounter <= 0 && lookingRight == false)
            {
                Instantiate(leftShuriken, leftFirePoint.position, leftFirePoint.rotation);
                shotDelayCounter = shotDelay;
            }
        }

        if (anim.GetBool("Sword"))
            anim.SetBool("Sword", false);

        if (Input.GetKey(KeyCode.C))
            anim.SetBool("Sword", true);

    }

    public void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, JumpHeight);
    }

}
