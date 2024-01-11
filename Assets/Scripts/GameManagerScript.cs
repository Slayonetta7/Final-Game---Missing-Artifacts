using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public GameObject pauseMenu;

    public GameObject player;

    public TMP_Text scoreText;
    public TMP_Text artifactText;
    public TMP_Text win;

    public TMP_Text healthText;
    public int health;
    public TMP_Text failText;

    public int score;
    public int artifact;
    public int specialPickup;
    public int numberOfSpecialForWin;

    public GameObject[] specialPickups;

    // Start is called before the first frame update
    void Start()
    {
        specialPickups = GameObject.FindGameObjectsWithTag("SpecialPickup");
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Gems: " + score;
        artifactText.text = "Artifacts: " + artifact;
        healthText.text = "Health: " + health;

        if(Input.GetKeyDown(name:"escape"))
        {
            pauseMenu.SetActive(true);
        }

        if (specialPickup == numberOfSpecialForWin)
        {
            win.gameObject.SetActive(true);
            win.text = "Congratulations, you have recovered all missing Artifacts!";
            specialPickup = 0;
        }
    }

    public void AddScore()
    {
        score = score + 1;
    }

    public void AddSpecialPickup()
    {
        if (specialPickup<numberOfSpecialForWin)
        {
            specialPickup = specialPickup + 1; 
            artifact = artifact + 1;
        }
        
    }

    public void DecreaseHealth()
    {
        health = health - 1;

        if (health <= 0)
        {
            Destroy(player);
            failText.gameObject.SetActive(true);
            failText.text = "You failed to retrieve the Artifacts!";
        } 
     }
}
