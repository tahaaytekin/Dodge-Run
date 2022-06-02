using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHareket : MonoBehaviour
{
   
    public GameObject tutorialPanel;
    public Animator playerAnimator;
    public float verticalSpeed;
    public bool firstDown;
    public Camera cam;
    [Header("Player Swipe Settings For PC")]
    public float roadSize = 10;
    public float swipeSpeed = 5;
    public float sensitive = 3;
    private float _initalX = 0;
    private float startX;
    public static PlayerHareket Instance;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        PlayerSwipe();
    }

    public void PlayerSwipe()
    {
        transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * verticalSpeed);
        if (Input.GetMouseButtonDown(0))
        {
            if (!firstDown)
            {
                firstDown = true;
                tutorialPanel.SetActive(false);
                verticalSpeed = 7;
                playerAnimator.SetTrigger("Run");

            }
            _initalX = cam.ScreenToViewportPoint(Input.mousePosition).x;
            startX = transform.localPosition.x;
        }

        if (Input.GetMouseButton(0))
        {
            float screenPos = cam.ScreenToViewportPoint(Input.mousePosition).x;
            screenPos = Mathf.Clamp(screenPos, 0, 1);

            float newX = startX + (roadSize / 2) * (screenPos - _initalX) * swipeSpeed;

            transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(newX, transform.localPosition.y, transform.localPosition.z), sensitive * Time.deltaTime);

            var localPos = transform.localPosition;
            localPos.x = Mathf.Clamp(localPos.x, -roadSize / 2, roadSize / 2);
            transform.localPosition = localPos;
        }
    }
}
