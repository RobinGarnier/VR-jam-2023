using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class vroomControl : MonoBehaviour
{
    public GameObject leftWheel;
    public GameObject rightWheel;

    public GameObject car;
    public GameObject forwRef;
    Rigidbody rigid;

    [Range(0, 90)] public float both;
    [Range(0, 90)] public float rotLeft;
    [Range(0, 90)] public float rotRight;
    float leftAnglePast=45f;
    float rightAnglePast=45f;

    public Vector3 forceL = Vector3.zero;
    public Vector3 forceR = Vector3.zero;
    public Vector3 forw = Vector3.zero;
    Vector3 forceLPast = Vector3.zero;
    Vector3 forceRPast = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        rigid = car.GetComponent<Rigidbody>();
        rotLeft = 45f;
        rotRight = 45f;
        both = 45f;
        forw = Forward();
    }

    // Update is called once per frame
    void Update()
    {
        //rotLeft = both;
        //rotRight = both;
        forw = Forward();

        //Left
        forceL = forw * (rotLeft-45)*1.2f;
        rigid.AddForceAtPosition(forceL, leftWheel.transform.position);
        
        //Right
        forceR = forw * (rotRight-45)*1.2f;
        rigid.AddForceAtPosition(forceR, rightWheel.transform.position);

        leftAnglePast = rotLeft;
        rightAnglePast = rotRight;

    }

    public float CheckAngle(float past, float lOrR)
    {
        float mesured;
        if (lOrR == 0){mesured = rotLeft;}
        else { mesured = rotRight; }

        return mesured - past;
    }

    public Vector3 Forward()
    {
        return Vector3.Normalize(forwRef.transform.position - car.transform.position);
    }
}
