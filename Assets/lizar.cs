using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class lizar : MonoBehaviour
{
 
  Rigidbody rb;
  public GameObject target;
  NavMeshAgent main;
   float Distantion;
  public GameObject Player1;
  public AudioSource am;
  //public AudioSource kill;
  public string wayPointType = "default";

  private void Start()
  {
    main = GetComponent<NavMeshAgent>();
    Randoms();
  }

  private void Update()
  {
    main.SetDestination(target.transform.position);

    Distantion = Vector3.Distance(main.transform.position, target.transform.position);

    float playerDistantion = Vector3.Distance(main.transform.position, Player1.transform.position);

    if (Distantion <= 1f) 
      Randoms();

    if (playerDistantion <= 4f)
      target = Player1;

    if (target == Player1 && playerDistantion >= 5f)
      Randoms();

    if (playerDistantion <= 1f)
    {
      //kill.Play();
    
      UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
  }


  private void Randoms()
  {
    WayPoint[] points = FindObjectsOfType<WayPoint>();
    List<WayPoint> ourPoints = new List<WayPoint>();
    foreach(var it in points)
    {
      if (it.type == wayPointType)
      {
        ourPoints.Add(it);
      }
    }

    int index = Random.Range(0, ourPoints.Count);
    target = ourPoints[index].gameObject;

  }
}