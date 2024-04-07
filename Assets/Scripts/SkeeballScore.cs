using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class SkeeballScore : MonoBehaviour
{

    
    private GameManager instance;
    public TextMeshProUGUI scoreAndBallsLeft;
    // Start is called before the first frame update
    void Start()
    {
        instance = GameManager.Instance;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreAndBallsLeft.text = "Score: " + instance.getScore().ToString() + "\n" + "Balls Left: " + instance.getBallCount().ToString();
    }

    private void OnTriggerEnter(Collider collision)
    {

        if(collision.gameObject.name == "Collider10")
        {
            Destroy(this.gameObject);
            instance.addScore(10);
           
        }
        else if(collision.gameObject.name == "Collider20")
        {
            Destroy(this.gameObject);
            instance.addScore(20);

        }
        else if (collision.gameObject.name == "Collider30")
        {
            Destroy(this.gameObject);
            instance.addScore(30);
            
        }
        else if (collision.gameObject.name == "Collider40")
        {
            Destroy(this.gameObject);
            instance.addScore(40);
            
        }
        else if (collision.gameObject.name == "Collider50")
        {
            Destroy(this.gameObject);
            instance.addScore(50);
            
        }
        else if (collision.gameObject.name == "Collider100")
        {
            Destroy(this.gameObject);
            instance.addScore(100);
        }
        Destroy(this.gameObject);

    }

   
}
