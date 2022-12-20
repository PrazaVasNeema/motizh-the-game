using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class CollectionHats : MonoBehaviour, CollectionItem
    {
        [SerializeField]
        private Transform m_hats;

        private int index = 0;

        void Start()
        {
            foreach (Transform child in m_hats)
            {
                child.gameObject.SetActive(false);
            }

            if (m_hats.childCount > 0)
            {
                m_hats.GetChild(index).gameObject.SetActive(true);
            }
        }

        public void ChangeItem(int dir)
        {
            m_hats.GetChild(index).gameObject.SetActive(false);
            index = (index + dir) % m_hats.childCount;
            index = index < 0 ? m_hats.childCount - 1: index;
            m_hats.GetChild(index).gameObject.SetActive(true);
        }
    }
}