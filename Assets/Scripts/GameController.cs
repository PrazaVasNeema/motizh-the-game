using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game{

    public class GameController : MonoBehaviour
    {
        [SerializeField]
        private StoneSpawner m_stoneSpawner;
        [SerializeField]
        private float m_power = 100f;
        [SerializeField]
        private UIScorePanel m_scorePanel;
        [SerializeField]
        private GameObject m_mainMenuPanel;
        [SerializeField]
        private GameObject m_gamePanel;
        [SerializeField]
        private GameSettings m_settings;

        private List<GameObject> m_stones = new();
        private int m_score = 0;
        private int m_maxScore = 0;
        private float m_timer = 0f;
        private float m_delay = 0f;
        private float m_maxDelay = 0f;

        private void Start()
        {
            ChangeGameState(false);
        }

        private void ChangeGameState(bool playModeNeedsToBeActivated)
        {
            enabled = playModeNeedsToBeActivated;
            m_mainMenuPanel.SetActive(!playModeNeedsToBeActivated);
            m_gamePanel.SetActive(playModeNeedsToBeActivated);
            if (playModeNeedsToBeActivated)
            {
                m_maxDelay = m_settings.maxDelay;
                m_delay = CalcNextDelay();
                m_score = 0;
            }
            else
            {
                ClearStones();
                m_score = m_maxScore;
            }
            RefreshScore(m_score);

        }
        private void Update()
        {
            m_timer += Time.deltaTime;
            if (m_timer >= m_delay)
            {
                var stone = m_stoneSpawner.Spawn();

                m_stones.Add(stone);
                m_timer -= m_delay;
                m_delay = CalcNextDelay();
                if (m_settings.minDelay < m_maxDelay)
                {
                    m_maxDelay -= m_settings.stepDelay;
                }
            }
        }

        private float CalcNextDelay()
        {
            var delay = Random.Range(m_settings.minDelay, m_maxDelay);
            return delay;
        }

        public void OnStartGame()
        {
            GameEvents.onGameOver += OnGameOver;
            ChangeGameState(true);
        }

        private void OnGameOver()
        {
            GameEvents.onGameOver -= OnGameOver;
            ChangeGameState(false);
        }

        private void ClearStones()
        {
            foreach (GameObject stone in m_stones)
            {
                Destroy(stone);
            }
            m_stones.Clear();
        }
        
        public void RefreshScore(int score)
        {
            m_scorePanel.SetScore(score);
        }


        public void OnCollisionStone(Collision collision)
        {
            if(collision.gameObject.TryGetComponent<Stone>(out var stone))
            {
    			var contact = collision.contacts[0];
    			var stick = contact.thisCollider.GetComponent<Stick>();
    			var body = stone.GetComponent<Rigidbody>();

                stone.SetAffect(false);
                body.AddForce(stick.dir * m_power, ForceMode.Impulse);
                Physics.IgnoreCollision(contact.thisCollider, contact.otherCollider, true);
                m_score++;
                RefreshScore(m_score);
            }
        }

        private void OnDestroy()
        {
            GameEvents.onGameOver -= OnGameOver;
        }

    }
}