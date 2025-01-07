using UnityEngine;

public class SoundRun : MonoBehaviour
{
  public PlayerMovement playerMove;
  public AudioSource moveSound;
  public AudioSource runSound;

  void Update()
  {
    switch (playerMove.MoveState)
    {
      case EMoveState.IDLE:
        moveSound.Stop();
        runSound.Stop();
        break;
      case EMoveState.MOVE:
        runSound.Stop();
        if (moveSound.isPlaying)
          return;
        else
          moveSound.Play();
        break;     
      case EMoveState.RUN:
        moveSound.Stop();
        if (runSound.isPlaying)
          return;
        else
          runSound.Play();
        break;
    }
  }
}