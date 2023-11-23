using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script : MonoBehaviour
{
public float Size;
public float YSizeMultiplier;
public float JumpForce; //declare variables at the start within the script

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.localScale = new Vector3(x: Size, y: Size*YSizeMultiplier, z: Size);
        
        gameObject.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
    
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Space))
      {
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up*JumpForce); 
      }
    }

    void OnCollisionEnter()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
    }
}
