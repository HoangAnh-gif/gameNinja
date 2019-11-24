using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D myRigidbody;

    private Animator myAnimator;

    [SerializeField]
    private float movementSpeed;
    private bool facingRight;
    private bool attack;

    // Start is called before the first frame update
    void Start()
    {
        facingRight = true;
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Debug.Log(horizontal);
        HandleMovement(horizontal);//player dich sang trai

        Flip(horizontal);
        
        HandleAttack();

        ResetValues();
    }

    private void HandleMovement(float horizontal)
    {
        if (!this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
        {
            myRigidbody.velocity = new Vector2(horizontal * movementSpeed, myRigidbody.velocity.y);
            //myRigidbody.velocity = Vector2.zero;
        }

        //myRigidbody.velocity = Vector2.left; 

        myAnimator.SetFloat("speed", Mathf.Abs( horizontal ));
    }

    private void HandleAttacks()
    {
        if(attack)
        {
            myAnimator.SetTrigger("attack");
            myRigidbody.velocity = Vector2.zero;
        }
    }

    private void HandleAttack()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            attack = true;
        }
    }

    private void Flip(float horizontal)
    {
        if ( horizontal > 0 && !facingRight || horizontal <0 && facingRight)
        {
            facingRight = !facingRight;

            Vector3 theScale = transform.localScale;

            theScale.x *= -1;

            transform.localScale = theScale;
        }
    }
    private void ResetValues()
    {
        attack = false;
    }
}
