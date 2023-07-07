using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject body;

    [SerializeField] private float rotationSpeed;
    
    public float health;
    [SerializeField] private Slider healthBar;
    public Enemy enemy;
    private float TotalHealth;

    private bool rotating;

    public bool grabed;
    
    // Start is called before the first frame update
    void Start()
    {
        rotating = false;
        grabed = false;
        TotalHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && !rotating)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                rotating = true;
                body.transform.DOLocalRotate(new Vector3(0, 330, 0), rotationSpeed, RotateMode.FastBeyond360).SetRelative(true)
                    .SetEase(Ease.Linear).OnComplete(() =>
                    {
                        grabed = true;
                        body.transform.Rotate(0,30f,0);
                        rotating = false;
                    });
            }
        }
        healthBar.value = health / TotalHealth;
    }
}
