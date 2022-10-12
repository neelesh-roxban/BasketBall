using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Transform target;
    private int score =0;
    [SerializeField] private GameObject ball;

    private void Awake()
   {
      if(instance == null)
      instance = this;
   }
    public void UpdateScore()
    {
        score++;
        Debug.Log(score);
    }

    public void SpawnBall()
    {
        Vector3 startPosition = new Vector3(0f,1.25f,-9f);
        GameObject ballClone=  Instantiate(ball,startPosition, Quaternion.identity);
        ballClone.GetComponent<Ball>().target = target;
        ballClone.GetComponent<Ball>().gameManager = instance;
    }
    
}
