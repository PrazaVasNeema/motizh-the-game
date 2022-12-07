using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStone : MonoBehaviour
{
    private Vector3 spawnOrigin;
    public GameObject stonePrefab;
    private int stoneCounter;

    void Start()
    {
        spawnOrigin = GetComponent<Transform>().position;
        stoneCounter = 1;
    }

    void Update()
    {
        if (Input.GetButtonDown("SpawnStone"))
        {
            SpawnStoneFunc();
        }
    }
    public void SpawnStoneFunc()
    {
        Instantiate(stonePrefab, new Vector3 (spawnOrigin.x, spawnOrigin.y + 50, spawnOrigin.z), Quaternion.identity);
        stoneCounter++;
    }
    public int GetStoneCounterValue()
    {
        return stoneCounter;
    }
}
