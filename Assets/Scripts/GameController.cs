using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game{

    public class GameController : MonoBehaviour
    {
        [SerializeField]
        private UIScorePanel m_scorePanel;
        [SerializeField]
        private IntroState m_introState;
        [SerializeField] 
        private MainMenuState m_mainMenuState;
        [SerializeField] 
        private GameState m_gameState;

        private int m_score = 0;
        private int m_maxScore = 0;
        public int maxScore => m_maxScore;
        public int score => m_score;




        private void Start()
        {
            SetIntroState();
        }

        public void SetIntroState()
        {
            m_introState.enabled = true;
            m_mainMenuState.enabled = false;
            m_gameState.enabled = false;
        }

        public void SetMainMenuState()
        {
            m_introState.enabled = false;
            m_mainMenuState.enabled = true;
            m_gameState.enabled = false;
        }

        public void SetGameState()
        {
            m_introState.enabled = false;
            m_mainMenuState.enabled = false;
            m_gameState.enabled = true;
        }

        public void StartGame()
        {
            SetGameState();
        }

        public void GameOver()
        {
            SetMainMenuState();
        }

        public void IncScore()
        {
            m_score++;
            m_maxScore = Mathf.Max(m_score, m_maxScore);
        }

        public void ResetScore()
        {
            m_score = 0;
        }

        public void RefreshScore(int score)
        {
            m_scorePanel.SetScore(score);
        }

        public void BringCameraToPoint(Transform point)
        {

        }

    }
}