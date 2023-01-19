using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float runSpeed;
    public float jumpSpeed;
    public float doubleJumpSpeed;
    private Rigidbody2D myRigidBody;
    private Animator myAnim;
    private BoxCollider2D myFeet;
    private bool isGround;
    private bool canDoubleJump;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        myFeet = GetComponent<BoxCollider2D>();
        canDoubleJump = true;
    }

    void CheckGrounded()
    {
        isGround = myFeet.IsTouchingLayers(LayerMask.GetMask("Ground"));
    }

    // Update is called once per frame
    void Update()
    {
        if(GlobalObject.isGameAlive) {
            Flip();
            CheckGrounded();
            Jump();
            Run();
            // Attack();
            SwitchAnimation();
        }
    }

    void Flip(){
        bool playerHasAxisSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        if(playerHasAxisSpeed) {
            if(myRigidBody.velocity.x > 0.1) {
                transform.localRotation = Quaternion.Euler(0,0,0);
            } else if(myRigidBody.velocity.x < -0.1){
                transform.localRotation = Quaternion.Euler(0,180,0);
            }
        }
    }

    void Jump() {
        if(Input.GetButtonDown("Jump")) {
            if(isGround) {
                Vector2 jumpVel = new Vector2(0.0f,jumpSpeed);
                myRigidBody.velocity = Vector2.up * jumpVel;
                myAnim.SetBool("jump",true);
                canDoubleJump = true;
            } else {
                if(canDoubleJump)
                {
                    Vector2 doubleJumpVel = new Vector2(0.0f,doubleJumpSpeed);
                    myRigidBody.velocity = Vector2.up * doubleJumpVel;
                    myAnim.SetBool("doublejump",true);
                    canDoubleJump = false;
                }
            }
        }
    }

    void Run()
    {
        float moveDir = Input.GetAxis("Horizontal");
        Vector2 playerVel = new Vector2(moveDir * runSpeed, myRigidBody.velocity.y);
        myRigidBody.velocity = playerVel;
        bool playerHasAxisSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        myAnim.SetBool("run",playerHasAxisSpeed);
    }

    void Attack()
    {
        if(Input.GetButtonDown("Attack")) {
            Debug.Log("Begin attack");
            myAnim.SetTrigger("attack");
        }
    }

    void SwitchAnimation()
    {
        // 一段跳
        myAnim.SetBool("idle",false);
        if(myAnim.GetBool("jump")) {
            if(myRigidBody.velocity.y < 0.0f) {
                myAnim.SetBool("jump",false);
                myAnim.SetBool("fall",true);
            }
        } else if(isGround) {
            myAnim.SetBool("fall",false);
            myAnim.SetBool("idle",true);
        }

        // 二段跳
        if(myAnim.GetBool("doublejump")) {
            if(myRigidBody.velocity.y < 0.0f) {
                myAnim.SetBool("doublejump",false);
                myAnim.SetBool("doublefall",true);
            }
        } else if(isGround) {
            myAnim.SetBool("doublefall",false);
            myAnim.SetBool("idle",true);
        }
    }
}
