using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playButton;//
    public GameObject playerShip;
    public GameObject enemySpawner;
    public GameObject GameOverGO;
    public GameObject ScoreUITextGO;
    public GameObject TimeCounterGO;
    public GameObject GameTitleGO;

    public enum GameManagerState
    {
        Opening,
        Gameplay,
        Gameover,
    }

    GameManagerState GMState;
    // Start is called before the first frame update
    void Start()
    {
        GMState = GameManagerState.Opening;
    }

    // Update is called once per frame
    void UpdateGameManagerState()
    {
        switch (GMState) {
            case GameManagerState.Opening:

                GameTitleGO.SetActive(true);
                GameOverGO.SetActive(false);
                playButton.SetActive(true);

                break;

            case GameManagerState.Gameplay:

                ScoreUITextGO.GetComponent<GameScore>().Score = 0;

               
                playButton.SetActive(false);
                playerShip.GetComponent<PlayerControl>().Init();
                GameTitleGO.SetActive(false);
                
                enemySpawner.GetComponent<EnemySpawner>().ScheduleEnemySpawner();
                TimeCounterGO.GetComponent<TimeCounter>().StartTimeCounter();
                break;

            case GameManagerState.Gameover:
                TimeCounterGO.GetComponent<TimeCounter>().StopTimeCounter();
                enemySpawner.GetComponent<EnemySpawner>().UnsheduleEnemySpawner();
                GameOverGO.SetActive(true);
                Invoke("ChangeToOpeningState", 8f);
                break;


        }
    }

    public void SetGameManagerState(GameManagerState state)
    {
        GMState = state;
        UpdateGameManagerState();
    }

    public void StartGamePlay()
    {
        GMState = GameManagerState.Gameplay;
        UpdateGameManagerState();
    }

    public void ChangeToOpeningState()
    {
        SetGameManagerState(GameManagerState.Opening);
    }
}
