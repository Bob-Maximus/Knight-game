using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordMovements : MonoBehaviour
{
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SwordInput();
    }

    void SwordInput()
    {
        if(Input.GetAxis("Mouse X") < 0  && Input.GetAxis("Mouse Y") < 0)
        {
            if (Input.GetMouseButton(0))
            {
                anim.Play("Attack Left");
            } else if (Input.GetMouseButton(1))
            {
                anim.Play("Block Left");
            }
            return;
        }

        if(Input.GetAxis("Mouse X") > 0 && Input.GetAxis("Mouse Y") < 0)
        {
            if (Input.GetMouseButton(0))
            {
                anim.Play("Attack Right");
            } else if (Input.GetMouseButton(1))
            {
                anim.Play("Block Right");
            }
            return;
        }

        if(Input.GetAxis("Mouse Y") > 0)
        {
            if (Input.GetMouseButton(0))
            {
                anim.Play("Attack Up");
            } else if (Input.GetMouseButton(1))
            {
                anim.Play("Block Up");
            }
            return;
        }

        if (Input.GetMouseButton(0))
        {
            anim.Play("Attack Straight");
        } else
        {
            anim.Play("Idle Straight");
        }
    }
}
