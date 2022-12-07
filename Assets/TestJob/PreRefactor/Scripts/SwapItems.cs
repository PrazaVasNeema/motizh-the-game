using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapItems : MonoBehaviour
{
    [SerializeField] private GameObject[] items;
    [SerializeField] private Mesh[] meshToUse;
    private int currentItemIndex;

    // Start is called before the first frame update
    void Start()
    {
        currentItemIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("SwapItems"))
        {
            SwapItemsFunc();

        }
    }
    public void SwapItemsFunc()
    {

        foreach (GameObject item in items)
        {
            if (item.GetComponent<MeshFilter>().mesh.vertexCount != meshToUse[currentItemIndex].vertexCount)
            {
                item.GetComponent<MeshFilter>().mesh = meshToUse[currentItemIndex];
            }
            else
            {
                if(currentItemIndex < meshToUse.Length - 1)
                {
                    item.GetComponent<MeshFilter>().mesh = meshToUse[currentItemIndex + 1];
                }
                else
                {
                    item.GetComponent<MeshFilter>().mesh = meshToUse[0];
                }
            }

           

        }
        currentItemIndex++;
        if (currentItemIndex >= meshToUse.Length)
        {
            currentItemIndex = 0;
        }
    }
}
