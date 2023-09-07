using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UIGameOver : MonoBehaviour
{

    public int displayedpoints = 0;
    public TextMeshProUGUI pointsUI;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnGameStateUpdate.AddListener(GameStateUpdated);
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnGameStateUpdate.RemoveListener(GameStateUpdated);
    }

    private void GameStateUpdated(GameManager.GameState newState)
    {
        if(newState == GameManager.GameState.GameOver)
        {
            displayedpoints = 0;
            StartCoroutine(DisplayedPointsCorouotine());
        }
    }

    IEnumerator DisplayedPointsCorouotine()
    {
        while(displayedpoints < GameManager.Instance.Points)
        {
            displayedpoints++;
            pointsUI.text = displayedpoints.ToString();
            yield return new WaitForFixedUpdate();
        }
        displayedpoints = GameManager.Instance.Points;
        pointsUI.text = displayedpoints.ToString();

        yield return null;
    }

    public void PlayAgaintBtnClicked()
    {
        GameManager.Instance.RestartGame();
    }

    public void ExitGameBtnClicked()
    {
        GameManager.Instance.ExitGame();
    }

}
