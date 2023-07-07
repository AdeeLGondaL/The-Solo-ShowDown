using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float health;
    [SerializeField] private Slider healthBar;
    private float TotalHealth;

    // Start is called before the first frame update
    void Start()
    {
        TotalHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = health / TotalHealth;
    }
}
