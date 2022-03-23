using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class player : MonoBehaviour
{
    
    Rigidbody2D rd;
    Animator animator;
    public Healthbar healthbar;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;

    const float groundCheckRadius = 0.2f;
    public float speed = 1;
    float horizontalValue;
    float isRunningModifier = 2f;
    [SerializeField] float isJumpPower = 500;

    bool facingRight = true;
    [SerializeField] bool isGrounded = false;
    [SerializeField] bool isRunning = false;
    [SerializeField] bool jump = false;

     void Awake()
    {
        rd = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
 
    void Update()
    {
      horizontalValue =  Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            isRunning = true;
        }else if(Input.GetKeyUp(KeyCode.RightShift))
        {
            isRunning = false;
        }
        // if press jump set jump enable
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            // if press jump set jump enable
            
        }
        else if (Input.GetButtonUp("Jump"))
        {
            jump = false;
        }
        if (Input.GetKey(KeyCode.Escape)) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

     void FixedUpdate()
    {
        GroundCheck();
        Move(horizontalValue,jump);
    }

    void GroundCheck()
    {
        isGrounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundCheckRadius, groundLayer);

        if (colliders.Length > 0)
        {
            isGrounded = true;
        }
    }

    void Move(float dir, bool jumpFlag)
    {
        if (isGrounded && jumpFlag)
        {
          
            isGrounded = false;
            jumpFlag = false;
            rd.AddForce(new Vector2(rd.velocity.x, isJumpPower));

            

        }

        #region Move & run
        float xVal = dir * speed * 100 * Time.fixedDeltaTime;
        if (isRunning == true)
        {
            xVal *= isRunningModifier;
        }
        Vector2 targetVelocity = new Vector2(xVal, rd.velocity.y);
        rd.velocity = targetVelocity;

        if(facingRight && dir < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            facingRight = false;

        }else if (!facingRight && dir > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            facingRight = true;
        }
        // idel 0, walk 3.6, run 7.2

        animator.SetFloat("xVelocity", Mathf.Abs(rd.velocity.x));
        #endregion
    }

    private void OnTriggerEnter2D(Collider2D bullet)
    {
        if(bullet.tag == "enemybullet")
        {
            healthbar.StateFind();
        }
    }
}
