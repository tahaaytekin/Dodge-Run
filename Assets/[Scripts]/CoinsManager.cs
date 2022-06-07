using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using System.Collections.Generic;
using System.Collections;

public class CoinsManager : MonoBehaviour
{
    public AudioClip coinSound;
    public int coinNum;
    public Text coinText;
    Camera cam;
    //References
    [SerializeField] GameObject animatedCoinPrefab;
    [SerializeField] Transform target;
    [Space]
    [Header("Available coins : (coins to pool)")]
    [SerializeField] int maxCoins;
    Queue<GameObject> coinsQueue = new Queue<GameObject>();
    [Space]
    [Header("Animation settings")]
    [Range(0.1f, 1f)] public float minAnimDuration;
    [Range(0.3f, 1f)] public float maxAnimDuration;
    [SerializeField] Ease easeType;
    [SerializeField] float spread;
    Vector3 targetPosition;
    private int _c = 0;

    public int Coins
    {
        get { return _c; }
        set
        {
            _c = value;

        }
    }

    void Awake()
    {
        targetPosition = target.position;
        cam = Camera.main;
        PrepareCoins(ref coinsQueue, animatedCoinPrefab);
        coinNum = PlayerPrefs.GetInt("coin", coinNum);
        coinText.text = coinNum.ToString();
    }
    void PrepareCoins(ref Queue<GameObject> dizi, GameObject p)
    {
        GameObject coin;
        for (int i = 0; i < maxCoins; i++)
        {
            coin = Instantiate(p);
            coin.transform.SetParent(transform, false);
            coin.SetActive(false);
            dizi.Enqueue(coin);
        }
    }
    void Animate(Vector3 collectedCoinPosition, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            if (coinsQueue.Count > 0)
            {
                GameObject coin = coinsQueue.Dequeue();
                coin.SetActive(true);
                Vector3 a = cam.WorldToScreenPoint(collectedCoinPosition);
                coin.transform.position = a + new Vector3(Random.Range(-spread, spread), Random.Range(-spread, spread), 0f);
                float duration = Random.Range(minAnimDuration, maxAnimDuration);
                coin.transform.DOScale(1f, duration).SetEase(easeType);
                coin.transform.DOMove(targetPosition, duration)
                .SetEase(easeType)
                .OnComplete(() =>
                {
                    coin.SetActive(false);
                    coinsQueue.Enqueue(coin);
                    Coins++;
                    coinNum++; coinText.text = coinNum.ToString();
                    PlayerPrefs.SetInt("coin", coinNum);


                    coinText.transform.DOScale(1.25f, 0.25f).SetEase(Ease.Linear).OnComplete(() =>
                    {
                        coinText.transform.DOScale(0.75f, 0.3f).SetEase(Ease.Linear);
                    });
                });
            }
        }
    }
    public void AddCoins(Vector3 collectedCoinPosition, int amount, bool state)
    {
        Animate(collectedCoinPosition, amount);
    }
}