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

		private int collectionIndex;

		private void OnEnable()
		{

			m_collections[0] = m_ch;
			m_collections[1] = m_cp;
			m_CollectionPanel.SetActive(true);
		}

		private void OnDisable()
		{
			m_CollectionPanel.SetActive(false);
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
		}

		public void ExitThisCollection()
		{
			m_ChooseItemPanel.SetActive(false);
		}

		public void ChangeThisItem(int dir)
        {
			m_collections[collectionIndex].ChangeItem(dir);
        }

	}
}
