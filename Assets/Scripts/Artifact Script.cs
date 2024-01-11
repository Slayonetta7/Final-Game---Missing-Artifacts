using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactScript : MonoBehaviour
{
     public GameManagerScript GameManager;
     public AudioClip ArtifactAudioClip;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = FindObjectOfType<GameManagerScript>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameManager.AddSpecialPickup();
            AudioSource.PlayClipAtPoint(ArtifactAudioClip, transform.position);
            Destroy(gameObject);
        }
    }
}
