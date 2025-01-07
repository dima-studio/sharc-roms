using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class answerLvL1 : MonoBehaviour
{
  public GameObject aN;
  public GameObject Player;
  public AudioSource pip;
   float Distantion;

  private void Update()
  {
    Distantion = Vector3.Distance(Player.transform.position, aN.transform.position);

    //float playerDistantion = Vector3.Distance(Player.transform.position, aN.transform.position);

    if (Distantion <= 1f && !pip.isPlaying)
    pip.Play();

    

     

    if (Distantion > 1f)
    pip.Stop();
  }










}
