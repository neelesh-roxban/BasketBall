using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEvents : MonoBehaviour
{
   public static GameEvents instance;
   [SerializeField] private UnityEvent ballScored;

   private void Awake()
   {
    instance = this;
   }


   public void OnBallScored()
   {
     ballScored?.Invoke();
   }
  
}
