using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordMovements : MonoBehaviour
{
    public Animator anim;
    private int stance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AttackBlock();
    }
    
    void AttackBlock()
    {
        if (Input.GetMouseButton(1))
        {
            if (Input.GetAxis("Mouse X") < 0  && Input.GetAxis("Mouse Y") < 0)
            {
                stance = 1;
                anim.Play("Block Left");
            } else if (Input.GetAxis("Mouse X") > 0 && Input.GetAxis("Mouse Y") < 0)
            {
                stance = 2;
                anim.Play("Block Right");
            } else if (Input.GetAxis("Mouse Y") > 0)
            {
                stance = 3;
                anim.Play("Block Up");
            } else
            {
                stance = 0;
                anim.Play("Idle Straight");
            }
        } else if (Input.GetMouseButtonDown(0)  && !anim.GetCurrentAnimatorClipInfo(0)[0].clip.name.Contains("Attack"))
        {
            if (stance == 1)
            {
                anim.Play("Attack Left");
            } else if (stance == 2)
            {
                anim.Play("Attack Right");
            } else if (stance == 3)
            {
                anim.Play("Attack Up");
            } else
            {
                anim.Play("Attack Straight");
            }
        }
    }
}
