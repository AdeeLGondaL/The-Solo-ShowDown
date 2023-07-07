using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float minDurationToReachTarget, maxDurationToReachTarget, speed;
    
    [SerializeField] private Vector3 finalPosition, originalPosition;
    [SerializeField] private float damageToPlayer, damageToEnemy;
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private GameObject fire;
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private ParticleSystem explosion;
    [SerializeField] private GameObject boomImage;
    private float timePassed;
    void Start()
    {
        timePassed = Time.time;
        explosion.Stop();
        originalPosition = transform.position;
        transform.DOMove(finalPosition,
            Random.Range(minDurationToReachTarget, maxDurationToReachTarget) * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        //Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == "Hand")
        {
            StartCoroutine("Grab", other);
        }
    }

    private IEnumerator Grab(Collision other)
    {
        var player = other.gameObject.GetComponentInParent<Player>();
        player.grabed = false;
        transform.parent = other.gameObject.transform;
        this.transform.DOScale(new Vector3(3f, 3f, 3f), 0f);
        yield return new WaitForSeconds(0.6f);
        if (player.grabed)
        {
            this.transform.parent = null;
            transform.DOMove(originalPosition - new Vector3(3,0,0), Random.Range(minDurationToReachTarget+5,maxDurationToReachTarget+5)*Time.deltaTime).OnComplete(() =>
            {
                player.grabed = false;
                Explode(player.enemy);
                CancelInvoke("Fire");
                Invoke("Fire", 2);
            });
        }
        else
        {
            Explode(player);
            CancelInvoke("Fire");
            Invoke("Fire", 2);
        }
        yield return new WaitForSeconds(0.3f);
        boomImage.SetActive(false);
    }

    private void Explode(Player player)
    {
        AudioManager.Instance.PlayBoomSound();
        boomImage.SetActive(true);
        explosion.Play();
        player.grabed = false;
        player.health -= damageToPlayer;
        meshRenderer.enabled = false;
        fire.SetActive(false);

    }
    private void Explode(Enemy enemy)
    {
        AudioManager.Instance.PlayBoomSound();
        boomImage.SetActive(true);
        explosion.Play();
        enemy.health -= damageToEnemy;
        meshRenderer.enabled = false;
        fire.SetActive(false);

    }
    private void Fire()
    {
        transform.position = originalPosition;
        boomImage.SetActive(false);
        explosion.Stop();
        meshRenderer.enabled = true;
        fire.SetActive(true);
        transform.DOMove(finalPosition,
            Random.Range(minDurationToReachTarget, maxDurationToReachTarget) * Time.deltaTime);
    }
}
