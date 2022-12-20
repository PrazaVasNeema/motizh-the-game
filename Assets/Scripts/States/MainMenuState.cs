using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{

	public class MainMenuState : MonoBehaviour
	{
		[SerializeField]
		private GameController m_gameController;
		[SerializeField]
		private CollectionsState m_collectionsState;
		[SerializeField]
		private GameObject m_mainMenuPanel;
		[SerializeField]
		private GameObject m_collectionsPanel;
		[SerializeField]
		private GameObject m_settingsPanel;
		[SerializeField]
		private MainCamera m_mainCamera;
		[SerializeField]
		private Transform[] m_mainCameraTransforms;
		[SerializeField]
		private DataController m_dataController;
		[SerializeField]
		private TMPro.TMP_Dropdown m_dropdown;

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

		public void EnterCollections()
        {
			m_collectionsState.enabled = true;
			this.enabled = false;
		}

		public void EnterSettings()
        {
			m_dropdown.value = m_dataController.m_gameData.difficultyLevel;
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

		public void SetDifficultyLevel()
        {
			Debug.Log(m_dropdown.value);
			int difficultyLevel = m_dropdown.value;
			m_dataController.m_gameData.difficultyLevel = difficultyLevel;
			m_dataController.SaveGameData();
		}
	}

}