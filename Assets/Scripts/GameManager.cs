using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player player;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.health < 0)
        {
            GameOver();
        }

        if (player.enemy.health < 0 && player.health > 0)
        {
            GameWon();
        }
    }

    void GameOver()
    {
        Time.timeScale = 0f;
        UIManager.Instance.GameOver.SetActive(true);
        UIManager.Instance.GameWin.SetActive(false);
    }

    public void RetryLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel()
    {
        
    }

    void GameWon()
    {
        Time.timeScale = 0f;
        UIManager.Instance.GameOver.SetActive(false);
        UIManager.Instance.GameWin.SetActive(true);
    }
}
