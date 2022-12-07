using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudLogics : MonoBehaviour
{
    [SerializeField] private GameObject[] villagers;
    private int currentWaypointIndex = 0;
    Vector3 currentDestination;

    public GameObject rainPrefab;
    public GameObject rain;

    public float smoothTime = 2f;
    private bool isMoving;
    private float startingDistance = .5f;

    protected Vector3 velocity = Vector3.zero;
    [SerializeField] private float maxSpeed = 7f;

    //[SerializeField] private float rainingTime = 3f;
    //private float startTime;

    void Start()
    {
        isMoving = true;
        SetMovingDestination();
    }

    private void Update()
    {
        if (Vector3.Distance(currentDestination, transform.position) < startingDistance && isMoving)
        {
            isMoving = false;
            //startTime = Time.time;
            rain = Instantiate(rainPrefab, transform.position, Quaternion.identity);
        }

        //if (Time.time - startTime > rainingTime && !isMoving)
        //{
        //    currentWaypointIndex++;
        //    if (currentWaypointIndex >= villagers.Length)
        //    {
        //        currentWaypointIndex = 0;
        //    }
        //    isMoving = true;
        //}
        //Kakaulin
        if (Input.GetButtonDown("MoveCloud") && !isMoving)
        {
            MoveCloudFunc();
        }
        if (isMoving)
//            transform.position = Vector3.MoveTowards(transform.position, currentDestination, Time.deltaTime * speed);
            transform.position = Vector3.SmoothDamp(transform.position, currentDestination, ref velocity, smoothTime, maxSpeed); // расчет перемещения камеры
    }
    public void MoveCloudFunc()
    {
        if (isMoving)
            return;
        currentWaypointIndex++;
        if (currentWaypointIndex >= villagers.Length)
        {
            currentWaypointIndex = 0;
        }
        isMoving = true;
        SetMovingDestination();
        rain.GetComponent<RainSelfDestructSequence>().InitiateDestroySequence();
    }
    private void SetMovingDestination()
    {
        currentDestination.x = villagers[currentWaypointIndex].transform.position.x;
        currentDestination.y = transform.position.y;
        currentDestination.z = villagers[currentWaypointIndex].transform.position.z;
    }
    public bool GetMovingStatus()
    {
        return isMoving;
    }
}