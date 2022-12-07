using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsController : MonoBehaviour
{
    [SerializeField] 
    private GameObject[] m_items;
    [SerializeField] 
    private Mesh[] m_meshToUse;
    private int m_currentItemIndex;

    // Start is called before the first frame update
    private void Awake()
    {
        m_currentItemIndex = 0;
    }

    // Update is called once per frame
/*    void Update()
    {
        if (Input.GetButtonDown("SwapItems"))
        {
            SwapItemsFunc();

        }
    }*/



    public void SwapItemsFunc()
    {

        foreach (GameObject item in m_items)
        {
            if (item.GetComponent<MeshFilter>().mesh.vertexCount != m_meshToUse[m_currentItemIndex].vertexCount)
            {
                item.GetComponent<MeshFilter>().mesh = m_meshToUse[m_currentItemIndex];
            }
            else
            {
                if (m_currentItemIndex < m_meshToUse.Length - 1)
                {
                    item.GetComponent<MeshFilter>().mesh = m_meshToUse[m_currentItemIndex + 1];
                }
                else
                {
                    item.GetComponent<MeshFilter>().mesh = m_meshToUse[0];
                }
            }



        }
        m_currentItemIndex++;
        if (m_currentItemIndex >= m_meshToUse.Length)
        {
            m_currentItemIndex = 0;
        }
    }
}
