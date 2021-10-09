using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigoutAttack : MonoBehaviour
{
    private Transform player;

    public Rigidbody rb;

    private float distToPlayer;
    private float dist;
    public float moveSpeed;
    public float howClose;

    private Animator bear_animator;

    public Transform waypoint;
    private bool attacked = false;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        bear_animator = GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>();

        rb.constraints = RigidbodyConstraints.FreezeAll;


    }

    private void Update()
    {
        distToPlayer = Vector3.Distance(player.position, transform.position);
        dist = Vector3.Distance(transform.position, waypoint.position);

        


        if (distToPlayer <= howClose)
        {
            Attack();

        }
        if (distToPlayer > howClose && attacked == true )
        {

            
            transform.LookAt(waypoint.position);

            if (dist > 10f)
            {
               
                transform.Translate(Vector3.forward * (moveSpeed + 3f) * Time.deltaTime);

            }
            else
            {
                bear_animator.SetBool("attack", false);
                moveSpeed = 0f;
                attacked = false;

            }

        }
           

    }

    void Attack()
    {
        attacked = true;
        moveSpeed = 5f;


        bear_animator.SetBool("attack", true);
        transform.LookAt(player);
        
        transform.Translate(Vector3.forward * (2 * moveSpeed) * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
            Destroy(gameObject);



    }

}
