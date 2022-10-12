using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Net : MonoBehaviour
{
    // Start is called before the first frame update
    public GameEvents gameEvents;
    public GameObject net;
    private int score = 0;
    private bool dirRight = true;
    public float speed = 4.0f;
 
     void Update () {
         if (dirRight)
             net.transform.Translate (Vector2.right * speed * Time.deltaTime);
         else
             net.transform.Translate (-Vector2.right * speed * Time.deltaTime);
         
         if(net.transform.position.x >= 2.5f) {
             dirRight = false;
         }
         
         if(net.transform.position.x <= -2.5) {
             dirRight = true;
         }
     }
     void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
      {
         gameEvents.OnBallScored();
      }
    }

    public int GetScore()
    {
        return score;
    }

   private void AddScore()
    {
        score++;
    }


   
}
