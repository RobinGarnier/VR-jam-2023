using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deplace : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent agent;

    [Header("Car RoadBook")]
    public Vector3 trajetA = Vector3.zero;[Tooltip("Pas touche")]
    Vector3 trajetB = Vector3.zero;

    [Header("Nav Proporties")]
    public GameObject destination; [Tooltip("Gameobject which have the transform of the final destination")]
    public bool launched;[Tooltip("Start the navigation with it")]

    [Header("Car Moving Parameter")]
    Vector3 position = Vector3.zero;
    Vector3 positionPresent = Vector3.zero;
    Vector3 positionPasse = Vector3.zero;
    Vector3 rot = Vector3.zero;
    float rotSpeed = 40f;
    Vector3 direction = Vector3.zero;
    float moveSpeed = 1.5f;
    GameObject car;

    

    // Start is called before the first frame update
    void Awake()
    {
        car = gameObject;
        agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();

        gameObject.transform.eulerAngles = rot;
        gameObject.transform.position = positionPasse;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(trajetA);
        
        if (launched)
        {
            { trajetA = destination.transform.position; }
        }
    }
}
