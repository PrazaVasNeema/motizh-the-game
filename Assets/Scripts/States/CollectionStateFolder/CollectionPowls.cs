using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class CollectionPowls : MonoBehaviour, CollectionItem
    {
        [SerializeField]
        private Transform m_plows;
        [SerializeField]
        private string[] m_label_text;
        [SerializeField]
        private TMPro.TMP_Text label;

        private int index = 0;

        void Start()
        {

        }
        public void LoadCollectionChoices(int index)
        {
            this.index = index;
            foreach (Transform child in m_plows)
            {
                child.gameObject.SetActive(false);
            }

            if (m_plows.childCount > 0)
            {
                label.text = m_label_text[index];
                m_plows.GetChild(index).gameObject.SetActive(true);
            }
        }

        public int ChangeItem(int dir)
        {
            m_plows.GetChild(index).gameObject.SetActive(false);
            index = (index + dir) % m_plows.childCount;
            index = index < 0 ? m_plows.childCount - 1 : index;
            m_plows.GetChild(index).gameObject.SetActive(true);
            label.text = m_label_text[index];
            return index;
        }
    }
}