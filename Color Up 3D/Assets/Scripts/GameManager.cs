using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation.Examples;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PathFollower follower;
    [SerializeField] private PathFollower followerCamera;
    private Player player;

    [SerializeField] private Button play;
    [SerializeField] private Button playAgain;

    [SerializeField] private GameObject victory;

    private ScoreManager scoreManager;

    private void Awake()
    {
        //Time.timeScale = 0.2f;

        scoreManager = FindObjectOfType<ScoreManager>();
        player = FindObjectOfType<Player>();

        if (PlayerPrefs.HasKey("IsStart"))
        {
            if (PlayerPrefs.GetInt("IsStart") == 0)
            {
                DoNotMove();
            }
            else
            {
                DoMove();
            }
        }
        else
        {
            PlayerPrefs.SetInt("IsStart", 1);
            DoNotMove();
        }   
    }

    private void DoNotMove()
    {
        follower.enabled = false;
        followerCamera.enabled = false;
        player.OffMove();
    }

    private void DoMove()
    {
        follower.enabled = true;
        followerCamera.enabled = true;
        player.OnMove();
        play.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (scoreManager.GetScore() < 0)
        {
            followerCamera.enabled = false;
            player.Die();
            playAgain.gameObject.SetActive(true);
        }

        if (player.transform.position.z > 698f)
        {
            player.Victory();
            play.gameObject.SetActive(true);
            victory.SetActive(true);
        }
    }

    public void PlayClick()
    {
        if (player.transform.position.z > 698f)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
        else
        {
            follower.enabled = true;
            followerCamera.enabled = true;
            player.OnMove();
            play.gameObject.SetActive(false);
        }
    }

    public void PlayAgainClick()
    {
        PlayerPrefs.SetInt("IsStart", 1);
        Application.LoadLevel(Application.loadedLevel);
    }

    public void Exit()
    {
        PlayerPrefs.SetInt("IsStart", 0);
        Application.Quit();
    }
}
