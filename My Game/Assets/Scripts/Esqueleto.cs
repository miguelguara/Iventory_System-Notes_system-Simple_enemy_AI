using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Esqueleto : MonoBehaviour
{
    private Transform playerPos;
    private Animator animator;
    public LayerMask mask;
    [SerializeField]
    private float speed,raioV,raioATK;
    public Transform atackpoint;
    bool Can_Walk = false;
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D c = Physics2D.OverlapCircle(transform.position, raioV,mask);
        if (c != null)
        {
            Can_Walk = true;
        }
        else
        {
            Can_Walk =false;
        }

        if(Can_Walk && speed > 0)
        {
            Move();
           
            animator.SetBool("walk", true);
            
        }
        else
        {
            animator.SetBool("walk", false);
        }


    }

    void Move()
    {
        Vector3 ps = new Vector3(playerPos.position.x, transform.position.y, 0f);
        transform.position = Vector2.MoveTowards(transform.position, ps, speed * Time.deltaTime);
        if(playerPos.position.x < transform.position.x)
        {
            transform.eulerAngles = Vector3.zero;
        }
        else
        {
            transform.eulerAngles = new Vector3(0f, 180f);
        }
        

    }

    IEnumerator Atack()
    {
        speed = 0f;
        animator.SetBool("Attack", true);
        yield return new WaitForSeconds(1.2f);
        animator.SetBool("Attack", false);
        yield return new WaitForSeconds(2f);
        StartCoroutine(Atack());
    }

    IEnumerator Perambular()
    {
        StopCoroutine(Atack());
        animator.SetBool("Attack", false);
        yield return new WaitForSeconds(2.5f);
        speed = 4f;
    }

    void DMGP()
    {
      Collider2D dm = Physics2D.OverlapCircle(atackpoint.position, raioATK,mask);
        if (dm != null)
        {
            Debug.Log("Acertou");
        }
    }
  
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, raioV);
        Gizmos.DrawWireSphere(atackpoint.position, raioATK);
    }

    private void OnTriggerEnter2D(Collider2D c)
    {
       if(c.gameObject.tag == "Player")
        {
            StartCoroutine(Atack());
        }
    }

    private void OnTriggerExit2D(Collider2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            StopAllCoroutines();
            StartCoroutine(Perambular());
        }
    }
}
