using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedLever : MonoBehaviour
{
    public GameObject car;
    public vroomControl vroom;

    public bool rightSide;
    // Start is called before the first frame update
    void Start()
    {
        vroom = car.GetComponent<vroomControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rightSide)
        {
            vroom.rotRight = transform.rotation.eulerAngles.x;
        }
        else
        {
            vroom.rotLeft = transform.rotation.eulerAngles.x;
        }
    }
}
