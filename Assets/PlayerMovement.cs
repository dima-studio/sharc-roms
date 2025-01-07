using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EMoveState
{
  IDLE,
  MOVE,
  RUN
}


public class PlayerMovement : MonoBehaviour
{

  public CharacterController controller;
  public Transform GroundCheck;
  public LayerMask groundMask;
  public float speed = 2.5f;
  public float speedRunMult = 1f;
  public float gravity = 9.8f;

  public AudioSource Music;
  public float jumpHeight = 3f;
  public float groundDistance = 0.4f;
  public Animator anim;
  public GameObject cam;
  public GameObject maincam;
  Vector3 velocity;

  bool isGrounded;


  public EMoveState MoveState
  {
    get;
    protected set;
  }

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    MoveState = EMoveState.IDLE;

    if (controller.isGrounded)
    {
      anim.SetFloat("X", Input.GetAxis("Horizontal"));
      anim.SetFloat("Y", Input.GetAxis("Vertical"));

    }
    isGrounded = Physics.CheckSphere(GroundCheck.position, groundDistance, groundMask);
    if (isGrounded && velocity.y < 0)
    {
      velocity.y = -2f;
    }
    float x = Input.GetAxis("Horizontal");
    float z = Input.GetAxis("Vertical");
    if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
    {

      velocity.y = Mathf.Sqrt(jumpHeight * gravity);
      anim.SetTrigger("Jump");
    }
    Vector3 move = transform.right * x + transform.forward * z;
    controller.Move(move * speed * speedRunMult * Time.deltaTime);
    velocity.y -= gravity * Time.deltaTime;
    controller.Move(velocity * Time.deltaTime);
    if (Input.GetKey("c"))
    {
      controller.height = 1f;
    }
    else
    {
      controller.height = 1.79f;
    }
    if (Input.GetKey("left shift") && move.magnitude > 0.1f)
    {
      speedRunMult = 2f;
      anim.SetFloat("Y", 2);
      //cam.SetActive(true);
      //maincam.SetActive(false);
      MoveState = EMoveState.RUN;
    }
    else if (move.magnitude > 0.1f)
    {
      speedRunMult = 1f;
      MoveState = EMoveState.MOVE;
      //cam.SetActive(false);
      //maincam.SetActive(true);
    }

     
    
  }
  private void OnTriggerEnter(Collider collision)
  {
    if (collision.gameObject.layer == 4)
    { 
      speed = 1.7f;
      Music.Play();
    }     
  } 

    private void OnTriggerExit(Collider collision)
  { 
    if (collision.gameObject.layer == 4)
    {
      speed = 2.5f;
      Music.Stop();
    }
  }
    











































































































}