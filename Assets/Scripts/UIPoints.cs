using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UIPoints : MonoBehaviour
{
    int displayedPoints = 0;
    public TextMeshProUGUI pointsLabel;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnPointsUpdate.AddListener(UpdatePoints);
        GameManager.Instance.OnGameStateUpdate.AddListener(GameStateUpdate);
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnPointsUpdate.RemoveListener(UpdatePoints);
        GameManager.Instance.OnGameStateUpdate.RemoveListener(GameStateUpdate);
    }

    private void GameStateUpdate(GameManager.GameState newState)
    {
        if(newState == GameManager.GameState.GameOver)
        {
            displayedPoints = 0;
            pointsLabel.text = displayedPoints.ToString();
        }
    }

    void UpdatePoints()
    {
        StartCoroutine(UpdatePointsCoroutine());
    }

    IEnumerator UpdatePointsCoroutine()
    {
        while(displayedPoints < GameManager.Instance.Points)
        {
            displayedPoints++;
            pointsLabel.text = displayedPoints.ToString();
            yield return new WaitForSeconds(0.1f);
        }
        yield return null;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
