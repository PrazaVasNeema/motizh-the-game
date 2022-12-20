using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class CollectionHats : MonoBehaviour, CollectionItem
    {
        [SerializeField]
        private Transform m_hats;
        [SerializeField]
        private string[] m_label_text;
        [SerializeField]
        private TMPro.TMP_Text label;

        private int index = 2;

        void Start()
        {
            foreach (Transform child in m_hats)
            {
                child.gameObject.SetActive(false);
            }

            if (m_hats.childCount > 0)
            {
                label.text = m_label_text[index];
                m_hats.GetChild(index).gameObject.SetActive(true);
            }
        }

        public int ChangeItem(int dir)
        {
            m_hats.GetChild(index).gameObject.SetActive(false);
            index = (index + dir) % m_hats.childCount;
            index = index < 0 ? m_hats.childCount - 1: index;
            m_hats.GetChild(index).gameObject.SetActive(true);
            label.text = m_label_text[index];
            return index;
        }
    }
}