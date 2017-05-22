using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    [HideInInspector]
    public bool facingRight = true;
    [HideInInspector]
    public bool jump = false;

    public float moveForce = 365f;
    public float maxSpeed = 1f;
    public float jumpForce = 250f;

    private Rigidbody2D rb2d;
    public new BoxCollider2D collider;

    private bool onGround = true;

    void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
    }
	
	// Update is called once per frame

    void Update()
    {
        int layerMask = Physics2D.AllLayers;
        if (collider.IsTouchingLayers(layerMask))
        {
            onGround = true;
        }
        else
        {
            onGround = false;
        }

        if(Input.GetKeyDown(KeyCode.Space) && onGround)

        {
            jump = true;
        }
    }
	void FixedUpdate ()
    {


        float h = Input.GetAxis("Horizontal");



        if (h * rb2d.velocity.x < maxSpeed)
        {
            rb2d.AddForce(Vector2.right * h * moveForce);
        }
        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
        {
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
        }
        if (h > 0 && !facingRight)
        {
            Flip();
        }
        if (h < 0 && facingRight)
        {
            Flip();
        }

        if(jump)
        {
            rb2d.AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }

    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
