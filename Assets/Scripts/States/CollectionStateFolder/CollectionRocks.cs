using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class CollectionRocks : MonoBehaviour, CollectionItem
    {
        [SerializeField]
        private Transform m_rocks;
        [SerializeField]
        private string[] m_label_text;
        [SerializeField]
        private TMPro.TMP_Text label;

        public int index = 2;

        void Start()
        {
            foreach (Transform child in m_rocks)
            {
                child.gameObject.SetActive(false);
            }

            if (m_rocks.childCount > 0)
            {
                label.text = m_label_text[index];
                m_rocks.GetChild(index).gameObject.SetActive(true);
            }
        }



        public int ChangeItem(int dir)
        {
            m_rocks.GetChild(index).gameObject.SetActive(false);
            index = (index + dir) % m_rocks.childCount;
            index = index < 0 ? m_rocks.childCount - 1 : index;
            m_rocks.GetChild(index).gameObject.SetActive(true);
            label.text = m_label_text[index];

            return index;

        }
    }
}