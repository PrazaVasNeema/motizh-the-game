using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Создаем префаб (задали точку инструмента, засунули скрипт)

public class Farmer : MonoBehaviour
{
    [SerializeField]
    Transform m_tools;

    private void Start()
    {
        foreach (Transform child in m_tools)
        {
            child.gameObject.SetActive(false);
        }

        if (m_tools.childCount > 0)
        {
            m_tools.GetChild(0).gameObject.SetActive(true);
        }
    }

    public void ChangeTool()
    {
        
        int index = -1;
        for (int i = 0; i < m_tools.childCount; i++)
        {
            if (m_tools.GetChild(i).gameObject.activeSelf)
            {
                index = i;
                break;
            }
        }

        if (index >= 0) // Нашли
        {
            m_tools.GetChild(index).gameObject.SetActive(false);

            index++;
            if (index < m_tools.childCount) // зациклили
            {
                index = 0;
            }

            m_tools.GetChild(index).gameObject.SetActive(true);
        }
    }
}
