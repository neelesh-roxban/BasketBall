using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Net : MonoBehaviour
{
    // Start is called before the first frame update
     public GameEvents gameEvents;
    private int score = 0;
   
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
