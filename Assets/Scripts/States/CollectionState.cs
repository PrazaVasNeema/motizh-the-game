using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class CollectionState : MonoBehaviour
    {
        [SerializeField]
        private CollectionHats[] m_collections;
		[SerializeField]
		private GameObject m_mainMenuPanel;
		[SerializeField]
		private GameObject m_CollectionPanel;
		[SerializeField]
		private GameObject m_ChooseItemPanel;

		private int collectionIndex;

		private void OnEnable()
		{
			m_CollectionPanel.SetActive(true);
		}

		private void OnDisable()
		{
			m_CollectionPanel.SetActive(false);
		}
		
		public void ExitCollections()
        {
			m_CollectionPanel.SetActive(false);
			m_mainMenuPanel.SetActive(true);
		}

		public void EnterThisCollection(int collectionIndex)
        {
			this.collectionIndex = collectionIndex;
			m_collections[collectionIndex].enabled = true;
			m_ChooseItemPanel.SetActive(true);
		}

		public void ExitThisCollection(int collectionIndex)
		{
			m_collections[collectionIndex].enabled = false;
			m_ChooseItemPanel.SetActive(false);
		}

		public void ChangeThisItem(int dir)
        {
			m_collections[collectionIndex].ChangeItem(dir);
        }

	}
}
