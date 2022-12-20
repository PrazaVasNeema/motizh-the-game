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
		private GameObject m_CollectionPanel;
		[SerializeField]
		private GameObject m_ChooseItemPanel;
		[SerializeField]
		private GameObject m_rockPreview;
		[SerializeField]
		private Transform[] m_targetTransforms;
		[SerializeField]
		private DataController m_dataController;

		private int collectionIndex;
		private float smoothFactor = 1f;
		private int targetTransformsIndex = 0;


		private void OnEnable()
		{

			m_collections[0] = m_ch;
			m_collections[1] = m_cp;
			m_collections[2] = m_cr;
		 
			m_CollectionPanel.SetActive(true);
		}

		private void OnDisable()
		{
			m_CollectionPanel.SetActive(false);
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
			m_ChooseItemPanel.SetActive(true);
			Exposition();
		}

		public void ExitThisCollection()
		{
			m_ChooseItemPanel.SetActive(false);
			DeExposition();
		}

		public void ChangeThisItem(int dir)
        {
			int choice = m_collections[collectionIndex].ChangeItem(dir);
			switch (collectionIndex)
            {
				case 0:
					break;
				case 1:
					break;
				case 2:
					m_dataController.m_gameData.rockChoice = choice;
					break;
            }
		}

		private void Exposition()
        {
			switch (collectionIndex)
            {
				case 0:
					break;
				case 1:
					break;
				case 2:
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
		}
	}
}
