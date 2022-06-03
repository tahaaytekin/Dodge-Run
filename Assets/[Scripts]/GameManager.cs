using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int maxColorChanging;

    public CoinsManager coinsManager;
    public int coinNum;
    public Text coinText;

    public float sayi;
    public float bolunecekSayi;
    public List<GameObject> objeler = new List<GameObject>();


    public ColourType oldType;
    public AudioSource audioSource;
    public AudioClip shootSound, itemSound,gateSound;
    public static GameManager Intance;
    public Color[] color;
    public Slider slider;
    private void Awake()
    {
        Intance = this;
    }
    private void Start()
    {
        foreach (var item in GameObject.FindGameObjectsWithTag("Item"))
        {
            objeler.Add(item);
        }
        sayi = objeler.Count;
        bolunecekSayi = 1 / sayi;
        print("bolunecek sayi: " + bolunecekSayi + "   " + sayi);
        coinsManager = GameObject.FindObjectOfType<CoinsManager>();
        //PlayerPrefs.GetInt("coin", coinNum);
       // coinText.text = coinNum.ToString();
    }
    public void DoColour(Color color, Item ıtem)
    {
     //   print(GameManager.Intance.oldType + "    " + ıtem.cType);
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
            maxColorChanging++;
            if (maxColorChanging>=5)
            {
                print("fail");
                PlayerHareket.Instance.verticalSpeed = 0;
                PlayerHareket.Instance.playerAnimator.SetTrigger("Fail");
            }
            //  Player.Instance.spawnedObject.GetComponent<MeshRenderer>().materials[0].color = color;
        }
        GameManager.Intance.oldType = ıtem.cType;
    }
    public IEnumerator TextDisplay()
    {
        yield return new WaitForSeconds(3.5f);
        print("girdi");
        coinsManager.AddCoins(Finish.Instance.megaEnemy.transform.position, coinNum, true);
        Invoke(nameof(SeviyeNext), 2f);
    }
    public void SeviyeNext()
    {
        GM.Instance.SeviyeAtlama();
    }
}
