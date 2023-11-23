using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exercise2GroundCheck : MonoBehaviour
{
public bool AmIOnTheGround;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter (Collider other) //when the groundcheck has a collider enter the ground, the varibale here becomes true
    {
        AmIOnTheGround = true;
    }

    private void OnTriggerExit (Collider other)
    {
        AmIOnTheGround = false;
    }
}
