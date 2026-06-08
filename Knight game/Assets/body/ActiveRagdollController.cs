using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ActiveRagdollController : MonoBehaviour
{
    public Transform[] transforms;
    public ConfigurableJoint[] joints;
    private Quaternion[] initialRotations;

    public bool balancing;
    public Rigidbody hips;
    public float legHeight;
    public float upForce;

    void Start()
    {
        //joints = new ConfigurableJoint[transforms.Count()-1];
        initialRotations = new Quaternion[transforms.Count()];

        for (int i = 0; i<joints.Count(); i++)
        {
            initialRotations[i] = transforms[i].rotation;
            //joints[i] = transforms[i+1].GetComponent<ConfigurableJoint>();
        }
    }

    void Update()
    {
        for (int i = 0; i<joints.Count(); i++)
        {
            if (joints[i].gameObject.name=="Lower Back")
            {
                joints[i].SetTargetRotationLocal(Quaternion.Euler(90, 0, 0), joints[i].transform.rotation);
                continue;
            }
            //joints[i].SetTargetRotationLocal(transforms[i].transform.rotation, joints[i].transform.rotation);
            ConfigurableJointExtensions.SetTargetRotationLocal(joints[i], transforms[i].transform.rotation, initialRotations[i]);
        } 

        if (balancing)
        {
            Balance();
        }
    }

    void Balance()
    {
        if (Physics.Raycast(hips.transform.position, Vector3.down, legHeight, 3))
        {
            //hips.AddForce(Vector3.up*upForce);
        }
    }
}
