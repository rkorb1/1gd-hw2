using UnityEngine;
using UnityEngine.InputSystem;
public class player_script : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float speed;
    public Rigidbody2D rb;
    public float jumpforce;
    bool isGrounded = false;
    
    public int coinsCollected = 0;

    private Animator playerAnim;

    private SpriteRenderer playerSpriteRenderer;
    bool isFacingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        playerAnim.SetBool("isGrounded", isGrounded);
    }

    void OnMove(InputValue value)
    {
        Vector2 v = value.Get<Vector2>();
        Debug.Log(v);

        rb.linearVelocity = new Vector2(v.x * speed, rb.linearVelocity.y);
        playerAnim.SetBool("isRun", rb.linearVelocity.x != 0);
        if((v.x < 0) && isFacingRight)
        {
            playerSpriteRenderer.flipX = true;
            isFacingRight = false;
        } 
        if((v.x > 0) && !isFacingRight)
        {
            playerSpriteRenderer.flipX = false;
            isFacingRight = true;
        }

    }

    void OnJump()
    {
        if(isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
        }   
    }

    void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Floor"))
        isGrounded = true;
}

void OnCollisionExit2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Floor"))
        isGrounded = false;
}
}
