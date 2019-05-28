using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{



    public Animator anim;
    private float inputH;
    private float inputV;
    public Rigidbody rbody;
    private bool run;


   

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody>();
        run = false;
    }

    // Update is called once per frame
    void Update()
    {
        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");

        anim.SetFloat("inputH", inputH);
        anim.SetFloat("inputV", inputV);
        anim.SetBool("run", run);

        float moveX = inputH * 20f * Time.deltaTime;
        float moveZ = inputV * 5f * Time.deltaTime;

        if (moveZ <=0f)
        {
            moveX = 0f;
        }

        rbody.velocity = new Vector3(moveX, 0f, moveZ);

        if (Input.GetKeyDown("1"))
        {
            anim.Play("WAIT01", -1, 0f);
        }
        if (Input.GetMouseButtonDown(0))
        {
            anim.Play("DAMAGED00", -1, 0f);
        }
        if (Input.GetMouseButtonDown(1))
        {
            anim.Play("DAMAGED01", -1, 0f);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            run = true;
        }
        else
        {
            run = false;
        }
        if (moveZ <= 0f)
        {
            moveX = 0f;
        }else if(run){
            moveX *= 3f;
            moveZ *= 3f;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("jump", true);
        }
        else
        {
            anim.SetBool("jump", false);
        }
        
    }
}