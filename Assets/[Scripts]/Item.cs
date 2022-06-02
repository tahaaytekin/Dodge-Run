using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ColourType { BLUE, PURPLE, RED, GREEN };
public class Item : MonoBehaviour
{
    public ColourType cType;

    public Color[] color;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("player'a degdi");
            Player p = other.GetComponentInParent<Player>();
            print(p.myType);
        }
    }
}
