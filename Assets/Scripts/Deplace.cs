using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deplace : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent agent;

    [Header("Car RoadBook")]
    [Tooltip("Pas touche")]public Vector3 trajetA = Vector3.zero;
    [Tooltip("Pas touche")] public bool tripFinished;

    [Header("Nav Proporties")]
    [Tooltip("Pas touche : List of Gameobject which have the transform of the potential final destination of the step(lenght=nb of children in drivable roads)")]public GameObject[] destinationsPossible;
    [Tooltip("number of different destination needed to bereach before the end")] public float nbEtape;
    [Tooltip("Pas touche : return all the destination needed to be reach")] public List<GameObject> destinationGlobal = new List<GameObject>();
    [Tooltip("Pas touche : return of the current destination")] public GameObject destination;
    [Tooltip("Start the navigation with it")]public bool launched;

    [Header("Checking and bug clearing ")]
    [Tooltip("Delay between each StuckCheck")][Range(0.5f,5f)] public float timerStuck;
    Vector3 positionPasse;
    float resteTimerStuck;
    public GameObject sun;
    public float rotateDelay;
    bool rotate;
    
    
    
    
    void Awake()
    {
        agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();


        destinationsPossible = GameObject.FindGameObjectsWithTag("drivable roads");

        List<GameObject> resteDestinationPossible = new List<GameObject>();
        foreach(GameObject obj in destinationsPossible)
        {
            resteDestinationPossible.Add(obj);
        }

        int indexRandom; 
        for (int i = 0; i < nbEtape; i++)
        {
            indexRandom = Random.Range(0, resteDestinationPossible.Count);
            destinationGlobal.Add(resteDestinationPossible[indexRandom]);
            resteDestinationPossible.RemoveAt(indexRandom);
        }


        destination.transform.position = destinationGlobal[0].transform.position;
        SetPosition(destination);


        resteTimerStuck = timerStuck;
    }


    void Update()
    {
        agent.SetDestination(trajetA);

       
        if (launched)
        {
            { trajetA = destination.transform.position; }
        }


        //if ((transform.position.x - 0.1<= destination.transform.position.x || destination.transform.position.x <= transform.position.x+0.1) && (destination.transform.position.z-0.1<= transform.position.z || transform.position.z <= destination.transform.position.z+ 0.1))
        if (transform.position.x== destination.transform.position.x && destination.transform.position.z == transform.position.z)
        {
            NvlleDirection();
        }

        if (launched)
        {
            resteTimerStuck-= Time.deltaTime;
            if (resteTimerStuck < 0)
            {
                StuckChecking(transform.position);
                positionPasse = transform.position;
                resteTimerStuck = timerStuck;
                rotate = false;
            }
            if (rotate)
            {
                sun.transform.Rotate((int)((140 / (nbEtape * 5)) * Time.deltaTime), 0, 0);
            }
        }

        
    }

    void SetPosition(GameObject destination)
    {
        destination.transform.position = new Vector3(destination.transform.position.x, 25 , destination.transform.position.z);
    }
    public void StuckChecking(Vector3 position)
    {
        if (position == positionPasse)
        {
            NvlleDirection();
        }
    }

    public void NvlleDirection()
    {
        try
        {
            destinationGlobal.RemoveAt(0);
            destination.transform.position = destinationGlobal[0].transform.position;
            SetPosition(destination);
            rotate = true;
        }
        catch
        {
            tripFinished = true;
        }
    }

    
}
