using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{

	public class GameState : MonoBehaviour
	{
		[SerializeField] private float m_power = 100f;
		[SerializeField]
		private GameController m_gameController;
		[SerializeField]
		private GameSettings[] m_settings;
		[SerializeField]
		private StoneSpawner m_stoneSpawner;
		[SerializeField]
		private GameObject m_gamePanel;
		[SerializeField]
		private DataController m_dataController;
		[SerializeField]
		private AudioController m_audioController;

		private float m_timer = 0f;
		private float m_delay = 0f;
		private float m_maxDelay = 0f;
		private List<GameObject> m_stones = new();
		private int m_settingsIndex;

		private void OnEnable()
		{
			m_settingsIndex = m_dataController.m_gameData.difficultyLevel;
			GameEvents.onCollisionStones += CheckGameOver;
			m_gamePanel.SetActive(true);

			m_maxDelay = m_settings[m_settingsIndex].maxDelay;

			m_gameController.ResetScore();
			m_gameController.RefreshScore(m_gameController.score);
		}

		private void OnDisable()
		{
			if (m_gamePanel != null)
			{
				m_gamePanel.SetActive(false);
			}
			ClearStones();
			GameEvents.onCollisionStones -= CheckGameOver;
		}

		private float CalcNextDelay()
		{
			var delay = Random.Range(m_settings[m_settingsIndex].minDelay, m_maxDelay);
			return delay;
		}

		private void ClearStones()
		{
			foreach (GameObject stone in m_stones)
			{
				StartCoroutine(m_gameController.DestroyStone(stone));
			}
			m_stones.Clear();
		}

		private void CheckGameOver(Stone stone1, Stone stone2)
		{
			if (stone1.isAffect && stone2.isAffect)
			{
				m_gameController.GameOver();
			}
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
				m_maxDelay = Mathf.Max(m_settings[m_settingsIndex].minDelay, m_maxDelay - m_settings[m_settingsIndex].stepDelay);
			}
		}

		public void OnCollisionStone(Collision collision)
		{
			if (collision.gameObject.TryGetComponent<Stone>(out var stone))
			{
				m_audioController.m_hitRockSoundEffect.Play();
				stone.isAffect = false;
				var contact = collision.contacts[0];

				var stick = contact.thisCollider.GetComponent<Stick>();

				var body = stone.GetComponent<Rigidbody>();
				body.AddForce(stick.dir * m_power, ForceMode.Impulse);

				m_gameController.IncScore();
				m_gameController.RefreshScore(m_gameController.score);

				Physics.IgnoreCollision(contact.thisCollider, contact.otherCollider, true);
			}
		}
	}
}