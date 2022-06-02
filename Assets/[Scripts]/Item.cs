using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ColourType { BLUE, PURPLE, RED, GREEN };
public class Item : MonoBehaviour
{

    public MeshRenderer mesh;

    public ColourType cType;

    public Color[] color;
    private void Start()
    {
        StartColor();
    }
    public void StartColor()
    {
        if (cType == ColourType.BLUE)
        {
            mesh.material.color = color[0];
        }
        else if (cType == ColourType.PURPLE)
        {
            mesh.material.color = color[1];
        }
        else if (cType == ColourType.RED)
        {
            mesh.material.color = color[2];
        }
        else if (cType == ColourType.GREEN)
        {
            mesh.material.color = color[3];
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player p = other.GetComponentInParent<Player>();
            p.ballCount++;
            if (cType == p.myType)
            {
                print("aynı renk aldın");
            }
            else
            {
                if (cType == ColourType.RED)
                {
                    print("rede dönüş");
                    GameManager.Intance.DoColour(color[2], this);
                }
                else if (cType == ColourType.BLUE)
                {
                    print("blue dönüş");
                    GameManager.Intance.DoColour(color[0], this);
                }
                else if (cType == ColourType.PURPLE)
                {
                    print("purpleColor dönüş");
                    GameManager.Intance.DoColour(color[1], this);
                }
                else if (cType == ColourType.GREEN)
                {
                    print("greenColor dönüş");
                    GameManager.Intance.DoColour(color[3], this);
                }
            }
        }
    }
}
