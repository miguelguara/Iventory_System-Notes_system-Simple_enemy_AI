using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    public float speed;
    public Vector2 move;
    [SerializeField]
    private float JumpForce;
    private Animator animator;
    private Rigidbody2D rb;
    public int jumps;
    [HideInInspector]
    public bool leadder = false;

    private SpriteRenderer ss;


    private bool Jumping = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        ss = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
    }


    void Update()
    {
         move = new Vector2(Input.GetAxis("Horizontal"), 0f);

        
        transform.Translate(move * speed * Time.deltaTime, Space.World);

        animator.SetFloat("Speed", move.magnitude);

        jump();
    

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }

        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }


    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Finish")
        {
            Jumping = false;
            jumps = 1;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Finish")
        {
            Jumping = true;
        }
    }

    void jump()
    {
        if (Input.GetButtonDown("Jump") && !Jumping)
        {
            rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        }
        else if (Input.GetButtonDown("Jump") && Jumping == true && jumps > 0)
        {
            animator.SetTrigger("DJ");
            rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            jumps--;
        }

        if (!Jumping)
        {
            animator.SetBool("Jump", false);
        }
        else
        {
            animator.SetBool("Jump", true);
        }
    }



 
}