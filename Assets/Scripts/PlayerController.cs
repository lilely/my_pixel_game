using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class PlayerController : MonoBehaviour
{
    public float runSpeed;
    public float jumpSpeed;
    public float doubleJumpSpeed;
    public float layerRestoreTime;
    public float climbSpeed;

    private Rigidbody2D myRigidBody;
    private Animator myAnim;
    private BoxCollider2D myFeet;
    private bool isGround;
    private bool canDoubleJump;
    private bool isOnOneWayPlatform;

    private bool isJumping;
    private bool isFalling;
    private bool isDoubleJumping;
    private bool isDoubleFalling;
    private bool isClimbing;
    private bool isOnLadder;
    private float playerGravity;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        myFeet = GetComponent<BoxCollider2D>();
        playerGravity = myRigidBody.gravityScale;
        canDoubleJump = true;
    }

    void CheckGrounded()
    {
        isGround = myFeet.IsTouchingLayers(LayerMask.GetMask("Ground")) ||
                    myFeet.IsTouchingLayers(LayerMask.GetMask("MovingPlatform")) ||
                    myFeet.IsTouchingLayers(LayerMask.GetMask("OnewayPlatform")) ;
        isOnOneWayPlatform = myFeet.IsTouchingLayers(LayerMask.GetMask("OnewayPlatform"));
    }

    void CheckLadder() 
    {
        isOnLadder = myFeet.IsTouchingLayers(LayerMask.GetMask("Ladder"));
    }

    // Update is called once per frame
    void Update()
    {
        if(GlobalObject.isGameAlive) {
            Flip();
            CheckGrounded();
            Jump();
            CheckLadder();
            CheckLadderState();
            Run();
            Climb();
            CheckOneWayPlatform();
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

    void Climb()
    {
        if(isOnLadder) {
            float moveY = Input.GetAxis("Vertical");
            if(moveY < -0.1 || moveY > 0.1) {
                myAnim.SetBool("climb",true);
                myAnim.SetBool("jump",false);
                myAnim.SetBool("doublejump",false);
                myAnim.SetBool("fall",false);
                myAnim.SetBool("doublefall",false);
                myRigidBody.gravityScale = 0.0f;
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, moveY * climbSpeed);
            } else {
                if((isJumping || isDoubleJumping || isFalling || isDoubleFalling) && !isClimbing) {
                    myAnim.SetBool("climb",false);
                    Debug.Log("Climbing when jumpppppp!!!!!!!!!");
                } else {
                    myAnim.SetBool("climb",false);
                    myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, 0);
                }
                
            }
        } else {
            myAnim.SetBool("climb",false);
            myRigidBody.gravityScale = playerGravity;
        }
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

    void CheckLadderState() {
        isJumping = myAnim.GetBool("jump");
        isFalling = myAnim.GetBool("fall");
        isDoubleJumping = myAnim.GetBool("doublejump");
        isDoubleFalling = myAnim.GetBool("doublefall");
        isClimbing = myAnim.GetBool("climb");
    }

    void CheckOneWayPlatform() {
        if(isGround && gameObject.layer != LayerMask.NameToLayer("Player")) {
            gameObject.layer = LayerMask.NameToLayer("Player");
        }
        float vertical = Input.GetAxis("Vertical");
        if(isOnOneWayPlatform && vertical < -0.1) {
            gameObject.layer = LayerMask.NameToLayer("OnewayPlatform");
            Invoke("restorePlayerLayer", layerRestoreTime);
        }
    }

    void restorePlayerLayer() {
        if(!isGround && gameObject.layer != LayerMask.NameToLayer("Player")) {
            gameObject.layer = LayerMask.NameToLayer("Player");
        }
    }
}
