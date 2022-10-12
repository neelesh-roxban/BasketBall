using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Transform target;
     public TextMeshProUGUI scoreUI;
    private int score =0;
    private string scoreText;
    [SerializeField] private GameObject ball;

    private void Awake()
   {
      if(instance == null)
      instance = this;
     // scoreText  = scoreUI.GetComponent<TMPro.TextMeshProUGUI>().text;
   }
    public void UpdateScore()
    {
        score++;
        Debug.Log(score);
        scoreUI.text = "Score: "+ score.ToString();
    }

    public void SpawnBall()
    {
        Invoke("spawn", 2);
      

        
        
    }
    private void spawn()
    {
      //  Vector3 startPosition = new Vector3(-1f,1.25f,-9f);
        Vector3 endPosition   = new Vector3(0f,1.25f,-9f );
        GameObject ballClone=  Instantiate(ball,endPosition, Quaternion.identity);
        ballClone.GetComponent<Ball>().target = target;
        ballClone.GetComponent<Ball>().gameManager = instance;
    }
    
}
