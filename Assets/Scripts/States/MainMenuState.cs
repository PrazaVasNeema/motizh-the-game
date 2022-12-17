using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{

	public class MainMenuState : MonoBehaviour
	{
		[SerializeField]
		private GameController m_gameController;
		[SerializeField]
		private GameObject m_mainMenuPanel;
		[SerializeField]
		private GameObject m_settingsPanel;
		[SerializeField]
		private MainCamera m_mainCamera;
		[SerializeField]
		private Transform[] m_mainCameraTransforms;

		private void OnEnable()
		{
			m_gameController.RefreshScore(m_gameController.maxScore);
			m_mainMenuPanel.SetActive(true);
		}

		private void OnDisable()
		{
			m_mainMenuPanel.SetActive(false);
		}

		public void PlayGame()
		{
			m_gameController.StartGame();
		}

		public void EnterSettings()
        {
			m_mainCamera.StriveForTransform(m_mainCameraTransforms[1]);
			m_mainMenuPanel.SetActive(false);
			m_settingsPanel.SetActive(true);
		}
		public void ExitSettings()
		{
			m_mainCamera.StriveForTransform(m_mainCameraTransforms[0]);
			m_mainMenuPanel.SetActive(true);
			m_settingsPanel.SetActive(false);
		}
	}

}