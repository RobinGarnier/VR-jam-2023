using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deplace : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent agent;

    [Header("Car RoadBook")]
    [Tooltip("Pas touche")]public Vector3 trajetA = Vector3.zero;
    Vector3 trajetB = Vector3.zero;
    [Tooltip("Pas touche")] public bool tripFinished;

    [Header("Nav Proporties")]
    [Tooltip("Pas touche : List of Gameobject which have the transform of the potential final destination of the step(lenght=nb of children in drivable roads)")]public GameObject[] destinationsPossible;
    [Tooltip("number of different destination needed to bereach before the end")] public float nbEtape;
    [Tooltip("Pas touche : return all the destination needed to be reach")] public List<GameObject> destinationGlobal = new List<GameObject>();
    [Tooltip("Pas touche : return of the current destination")] public GameObject destination;
    [Tooltip("Start the navigation with it")]public bool launched;


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
    }


    void Update()
    {
        agent.SetDestination(trajetA);
        
        if (launched)
        {
            { trajetA = destination.transform.position; }
        }

        //if ((transform.position.x - 0.1<= destination.transform.position.x || destination.transform.position.x <= transform.position.x+0.1) && (destination.transform.position.z-0.1<= transform.position.z || transform.position.z <= destination.transform.position.z+ 0.1))
        if (transform.position.x== destination.transform.position.x && destination.transform.position.x == transform.position.x)
        {
            try 
            {
                destinationGlobal.RemoveAt(0);
                destination.transform.position = destinationGlobal[0].transform.position;
                SetPosition(destination);
            }
            catch
            {
                tripFinished = true;
            }
        }
    }

    void SetPosition(GameObject destination)
    {
        destination.transform.position = new Vector3(destination.transform.position.x, 25 , destination.transform.position.z);
    }

}
