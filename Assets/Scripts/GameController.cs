using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game{

    public class GameController : MonoBehaviour
    {
        [SerializeField] // Берем за привычку все защищать
        private StoneSpawner m_stoneSpawner;
        private float m_timer = 0f;
        [SerializeField]
        private float m_delay = 1f;

        [SerializeField]
        private float m_power = 100f;

        [SerializeField]
        private UIScorePanel m_scorePanel;
        [SerializeField]
        private GameObject m_mainMenuPanel;
        [SerializeField]
        private GameObject m_gamePanel;

        [SerializeField]
        private GameSettings m_gameSettings;

        private List<GameObject> m_stone = new();

        private int m_score = 0;
        private int m_maxScore = 0;

        // Кешируем значение

        public void MainMenuState()
        {
                    ClearStones();

                    enabled = true;
                    m_mainMenuPanel.SetActive(true);
                    m_gamePanel.SetActive(false);
                    RefreshScore(m_maxScore);
        }

        private void GameState()
        {
                    // !

                    enabled = false;

                    m_mainMenuPanel.SetActive(true);
                    m_gamePanel.SetActive(false);
                    m_score = 0;
                    RefreshScore(m_score);

                    StartGame();

        }


        private void Start()
        {
            StartGame();

            //Debug.Log($"GameSettings.num = {m_settings.num}");
        }

        private void StartGame()
        {
            GameEvents.onGameOver += OnGameOver; // Подписались
        }

        private void ClearStones()
        {
                    foreach (GameObject stone in m_stone)
                    {
                        Destroy(stone);
                    }
        }

        private void OnGameOver()
        {
            GameEvents.onGameOver -= OnGameOver;
            Debug.Log("Tis' Over");

            MainMenuState();
            // !
        }

        private void Update()
        {
            m_timer += Time.deltaTime;
            if (m_timer >= m_delay) // !
            {
                // !
                m_stoneSpawner.Spawn();
                m_timer -= m_delay;
            }
        }
        
        public void RefreshScore(int score)
        {
            
            m_scorePanel.SetScore(score);
        }


        public void OnCollisionStone(Collision collision)
        {
            // Понять, что это камень, можно через тег или через слой или через компонент
            if(collision.gameObject.TryGetComponent<Stone>(out var stone)) // Можно динамически создавать переменные
            {
                // stone.SetAffect(false);
                // var contact = collision.contacts[0]; // Лучше делать так, а не постоянно вызывать дальше
                // // А еще лучше сделать отдельный метод
                // var body = contact.otherCollider.GetComponent<Rigidbody>();
                // body.AddForce(-contact.normal * m_power);
                // Physics.IgnoreCollision(contact.thisCollider, contact.otherCollider, true);

    /*            if (stone.gameObject.tag == "Stone2") // Очень тяжело
                {

                }

                if (stone.gameObject.CompareTag("Stone2")) // Почти бесплатно
                {

                }*/
                m_score++;
                RefreshScore(m_score);
                stone.SetAffect(false);
    				var contact = collision.contacts[0];

    				var stick = contact.thisCollider.GetComponent<Stick>();
    
    				var body = stone.GetComponent<Rigidbody>();
    				body.AddForce(stick.dir * m_power, ForceMode.Impulse);
    
    				Physics.IgnoreCollision(contact.thisCollider, contact.otherCollider, true);

            }
        }

        private void OnDestroy()
        {
            GameEvents.onGameOver -= OnGameOver;
        }

    }
}

// Коллизия - класс, содержащий информацию о столкновении двух тел
// Коллизия есть всегда