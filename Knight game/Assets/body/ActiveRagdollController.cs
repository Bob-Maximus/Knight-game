using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ActiveRagdollController : MonoBehaviour
{
    public Transform[] transforms;
    public ConfigurableJoint[] joints;
    private Quaternion[] initialRotations;

    void Start()
    {
        joints = new ConfigurableJoint[transforms.Count()-1];
        initialRotations = new Quaternion[transforms.Count()-1];

        for (int i = 0; i<joints.Count(); i++)
        {
            initialRotations[i] = transforms[i+1].rotation;
            joints[i] = transforms[i+1].GetComponent<ConfigurableJoint>();
        }
    }

    void Update()
    {
        for (int i = 0; i<joints.Count(); i++)
        {
            joints[i].targetRotation = transforms[i+1].rotation;
        } 
    }
}
