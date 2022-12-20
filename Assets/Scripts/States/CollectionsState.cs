using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class CollectionsState : MonoBehaviour
    {
        [SerializeField]
        public CollectionItem[] m_collections = new CollectionItem[3];
		[SerializeField]
		public CollectionHats m_ch;
		[SerializeField]
		public CollectionPowls m_cp;
		[SerializeField]
		public CollectionRocks m_cr;
		[SerializeField]
		private MainMenuState m_mainMenuState;
		[SerializeField]
		private GameObject m_mainMenuPanel;
		[SerializeField]
		private GameObject m_collectionPanel;
		[SerializeField]
		private GameObject m_chooseItemPanel;
		[SerializeField]
		private GameObject m_rockPreview;
		[SerializeField]
		private Transform[] m_targetTransforms;
		[SerializeField]
		private DataController m_dataController;
		[SerializeField]
		private MainCamera m_mainCamera;
		[SerializeField]
		private Transform[] m_mainCameraTransforms;

		private int collectionIndex;
		private float smoothFactor = 1f;
		private int targetTransformsIndex = 0;


		private void OnEnable()
		{


		 
			m_collectionPanel.SetActive(true);
		}

		private void OnDisable()
		{
			m_collectionPanel.SetActive(false);
		}

		public void LoadCollectionsState()
        {
			m_collections[0] = m_ch;
			m_collections[1] = m_cp;
			m_collections[2] = m_cr;
			m_collections[0].LoadCollectionChoices(m_dataController.m_gameData.hatChoice);
			m_collections[1].LoadCollectionChoices(m_dataController.m_gameData.plowChoice);
			m_collections[2].LoadCollectionChoices(m_dataController.m_gameData.rockChoice);
		}

		private void Update()
        {
			if (Vector3.Distance(m_rockPreview.transform.position, m_targetTransforms[targetTransformsIndex].position) > .1f)
			{
				Vector3 smoothPosition = Vector3.Lerp(m_rockPreview.transform.position, m_targetTransforms[targetTransformsIndex].position, smoothFactor * Time.fixedDeltaTime);
				m_rockPreview.transform.position = smoothPosition;
			}
		}

        public void ExitCollections()
        {
			m_mainMenuState.enabled = true;
			this.enabled = false;
		}

		public void EnterThisCollection(int collectionIndex)
        {
			this.collectionIndex = collectionIndex;
			m_chooseItemPanel.SetActive(true);
			m_collectionPanel.SetActive(false);
			Exposition();
			m_collections[collectionIndex].ChangeItem(0);
		}

		public void ExitThisCollection()
		{
			m_chooseItemPanel.SetActive(false);
			m_collectionPanel.SetActive(true);
			DeExposition();
		}

		public void ChangeThisItem(int dir)
        {
			int choice = m_collections[collectionIndex].ChangeItem(dir);
			switch (collectionIndex)
            {
				case 0:
					m_dataController.m_gameData.hatChoice = choice;
					break;
				case 1:
					m_dataController.m_gameData.plowChoice = choice;
					break;
				case 2:
					m_dataController.m_gameData.rockChoice = choice;
					break;
            }
			m_dataController.SaveGameData();
		}

		private void Exposition()
        {
			switch (collectionIndex)
            {
				case 0:
					m_mainCamera.StriveForTransform(m_mainCameraTransforms[1]);
					break;
				case 1:
					m_mainCamera.StriveForTransform(m_mainCameraTransforms[2]);
					break;
				case 2:
					m_mainCamera.StriveForTransform(m_mainCameraTransforms[3]);
					targetTransformsIndex = 1;
					break;

            }
        }

		private void DeExposition()
        {
			switch (collectionIndex)
			{
				case 0:
					break;
				case 1:
					break;
				case 2:
					targetTransformsIndex = 0;
					break;
			}
			m_mainCamera.StriveForTransform(m_mainCameraTransforms[0]);
		}
	}
}
