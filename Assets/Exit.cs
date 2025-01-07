using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
  public GameObject Player123;
  public GameObject Exit1;
   float Distantion;

  private void Update()
  {
    Distantion = Vector3.Distance(Player123.transform.position, Exit1.transform.position);

    if (Distantion < 1f)
      UnityEngine.SceneManagement.SceneManager.LoadScene(1);

  }

































}
