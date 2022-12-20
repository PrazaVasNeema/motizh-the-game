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
        private CollectionsState m_collectionsState;
        [SerializeField] 
        private GameState m_gameState;
        [SerializeField]
        private DataController m_dataController;
        [SerializeField]
        private AudioController m_audioController;

        private int m_score = 0;
        private int m_maxScoreNormal;
        public int maxScoreNormal => m_maxScoreNormal;
        private int m_maxScoreHard;
        public int maxScoreHard => m_maxScoreHard;
        public int score => m_score;




        private void Start()
        {
            m_dataController.InitData();
            m_maxScoreNormal = m_dataController.m_gameData.maxScoreNormal;
            m_maxScoreHard = m_dataController.m_gameData.maxScoreHard;
            m_collectionsState.LoadCollectionsState();
            m_audioController.SetMusicStatus(m_dataController.m_gameData.musicCheckbox);
            SetIntroState();
            RefreshScoreRecords(m_maxScoreNormal, m_maxScoreHard);
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
            m_scorePanel.SetScorePanelDifficultyLevel(m_dataController.m_gameData.difficultyLevel);
        }

        public void GameOver()
        {
            Debug.Log(m_dataController.m_gameData.difficultyLevel);
            switch (m_dataController.m_gameData.difficultyLevel)
            {
                case 0:
                    m_maxScoreNormal = Mathf.Max(m_score, m_maxScoreNormal);
                    m_dataController.m_gameData.maxScoreNormal = m_maxScoreNormal;
                    break;
                case 1:
                    m_maxScoreHard = Mathf.Max(m_score, m_maxScoreHard);
                    m_dataController.m_gameData.maxScoreHard = m_maxScoreHard;
                    break;
            }
           
            m_dataController.SaveGameData();
            SetMainMenuState();
        }

        public void IncScore()
        {
            m_score++;
        }

        public void ResetScore()
        {
            m_score = 0;
        }

        public void RefreshScoreRecords(int scoreNormal, int scoreHard)
        {
            m_scorePanel.SetScoreNormal(scoreNormal);
            m_scorePanel.SetScoreHard(scoreHard);
        }
        public void RefreshScoreIngame(int score)
        {
            m_scorePanel.SetScoreIngame(score);
        }

        public void BringCameraToPoint(Transform point)
        {

        }

        public IEnumerator DestroyStone(GameObject stone)
        {
            GameObject sphere = stone.gameObject.transform.GetChild(0).gameObject;
            sphere.SetActive(true);
            Debug.Log("this");

            m_audioController.m_disappearRockSoundEffect.Play();
            Debug.Log("this");

            while (stone.gameObject.transform.localScale.x > 0.001f)
            {
                stone.gameObject.transform.localScale -= new Vector3(0.03f, 0.03f, 0.03f);
                //yield return null;
                yield return new WaitForSeconds(.1f);
                Debug.Log("this");
            }
            Destroy(stone);
            Debug.Log("this");
        }
        
        public void Quit()
        {
            Application.Quit();
        }
    }
}