using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public AudioClip moveSFX;
    public AudioClip missSFX;
    public AudioClip matchSFX;
    public AudioClip gameOverSFX;

    public AudioSource SfxSource;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnPointsUpdate.AddListener(PointsUpdate);
        GameManager.Instance.OnGameStateUpdate.AddListener(GameStateUpdated);
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnPointsUpdate.RemoveListener(PointsUpdate);
        GameManager.Instance.OnGameStateUpdate.RemoveListener(GameStateUpdated);
    }

    private void GameStateUpdated(GameManager.GameState newState)
    {
        if(newState == GameManager.GameState.GameOver)
        {
            SfxSource.PlayOneShot(gameOverSFX);
        }
        if(newState == GameManager.GameState.InGame)
        {
            SfxSource.PlayOneShot(matchSFX);
        }
    }

    private void PointsUpdate()
    {
        SfxSource.PlayOneShot(matchSFX);
    }

    public void Move()
    {
        SfxSource.PlayOneShot(moveSFX);
    }

    public void Miss()
    {
        SfxSource.PlayOneShot(missSFX);
    }
}
