using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCharacterController : MonoBehaviour
{
    //movement variables
    public float moveForce;
    public float maxSpeed;
    public float jumpForce;
    private Rigidbody myRigidbody; //renames the rigidbody 

    public GameObject groundcheck;

    //rotation variables
    public GameObject child; //watch out for capital letters in naming varibales! 
    public float rotateSpeed;
    public float rotationSensitivity;

    //animation varibales
    public Animator playerAnimator;

    public GameObject myParticle;


    // Start is called before the first frame update
    void Start()
    {
       myRigidbody = gameObject.GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        //move Code starts
        if(Mathf.Abs(myRigidbody.velocity.magnitude) < maxSpeed) //checks if rigidbody moves slower than the maxSpeed 
        {
            myRigidbody.AddForce( x:(Input.GetAxis("Horizontal") * moveForce), y:0, z:(Input.GetAxis("Vertical") * moveForce)); //applies force in the forward (vertical, z axis)
        } //move Code ends

        if(Mathf.Abs(myRigidbody.velocity.magnitude) > 0)
        {
            myParticle.SetActive(true);
        }else if (Mathf.Abs(myRigidbody.velocity.magnitude) == 0)
        {
            myParticle.SetActive(false);
        }

        //jump code starts
        if(Input.GetButtonDown("Jump") && groundcheck.GetComponent<Exercise2GroundCheck>().AmIOnTheGround == true) //checks is player is on ground or not
        {
            myRigidbody.AddForce(x:0, y:jumpForce, z:0);
        } //jump code ends

        //rotation code starts
        Vector3 moveDirection = new Vector3(myRigidbody.velocity.x, y:0, myRigidbody.velocity.z);
        if(moveDirection.magnitude > rotationSensitivity)
        {
            //Debug.Log("rotating to" + moveDirection)
            child.transform.rotation = Quaternion.Slerp(a: child.transform.rotation, b: Quaternion.LookRotation(moveDirection), t: Time.deltaTime * rotateSpeed); //changing child rotation, Quaternion is used to change rotation, Euler angles are used as alternatives, but rarely
        } //rotation code ends

        //animation code begins
        playerAnimator.SetFloat(name:"speed", moveDirection.magnitude);
        playerAnimator.SetFloat(name:"verticalSpeed", myRigidbody.velocity.y);
        playerAnimator.SetBool(name:"AmIGrounded", groundcheck.GetComponent<Exercise2GroundCheck>().AmIOnTheGround);
    }
}
