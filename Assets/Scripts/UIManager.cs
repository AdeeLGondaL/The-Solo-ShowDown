using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject startingPanel, GameOver, GameWin;

    private bool levelStart;
    // Start is called before the first frame update
    void Start()
    {
        levelStart = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && levelStart)
        {
            levelStart = false;
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                startingPanel.gameObject.SetActive(false);
                Time.timeScale = 1f;
            }
        }
    }

    #region Singleton

    public static UIManager Instance;

    private void Awake()
    {
        if (Instance != this)
        {
            Destroy(Instance);
        }

        Instance = this;
    }

    #endregion
}
