using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishPlane : MonoBehaviour
{
   
    public Text planeText;
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MegaEnemy"))
        {
            GameManager.Intance.coinNum = int.Parse(planeText.text);
            
        }
    }
   
}
