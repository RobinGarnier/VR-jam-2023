using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{
    public GameObject followed;
    [Range(0,360)]public float rotation;
    float rot;
    float rotationPasse;
    bool needRotate;
    
    // Update is called once per frame
    void Update()
    {
        if (rotationPasse != rotation){ needRotate = true; }

        transform.position = followed.transform.position;
        if (needRotate)
        {
            rot = rotation - transform.rotation.y;
            transform.Rotate(0, rot, 0);
            needRotate = false;
        }
        rotationPasse = rotation;
    }
}
