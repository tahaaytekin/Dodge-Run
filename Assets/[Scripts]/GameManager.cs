using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ColourType oldType;
    public AudioSource audioSource;
    public AudioClip shootSound;
    public static GameManager Intance;
    public Color[] color;
    private void Awake()
    {
        Intance = this;
    }

    public void DoColour(Color color, Item ıtem)
    {
        print(GameManager.Intance.oldType + "    " + ıtem.cType);
        if (GameManager.Intance.oldType == ıtem.cType)
        {
            Player.Instance.colourRank++;
            print("colour rank arttı" + "    " + Player.Instance.colourRank);
        }
        else
        {
            Player.Instance.colourRank = 1;

            print("colour rank 1 oldu");
        }
        if (Player.Instance.colourRank == 1)
        {
            Player.Instance.mesh.materials[0].color = color;
        }
        else if (Player.Instance.colourRank == 2)
        {
            Player.Instance.mesh.sharedMaterials[1].color = color;
        }
        else if (Player.Instance.colourRank == 3)
        {
            Player.Instance.mesh.sharedMaterials[2].color = color;
            Player.Instance.myType = ıtem.cType;
          //  Player.Instance.spawnedObject.GetComponent<MeshRenderer>().materials[0].color = color;
        }
        GameManager.Intance.oldType = ıtem.cType;
    }

}
