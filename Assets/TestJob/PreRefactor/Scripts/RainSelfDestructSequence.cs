using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainSelfDestructSequence : MonoBehaviour
{
    [SerializeField] private float timeToDestroy = 5f;
    private float startTime;
    private bool destroySequenceInitiated = false;
    private ParticleSystem ps;
    // Start is called before the first frame update
    void Start()
    {
        //startTime = Time.time;
        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Time.time - startTime > timeToDestroy)
        //   Destroy(this.gameObject);
          
        ////if (Input.GetButtonDown("MoveCloud"))
        ////{
        ////    InitiateDestroySequence();
        ////}
        if (destroySequenceInitiated)
        {
            if (Time.time - startTime > timeToDestroy)
            {
                Destroy(this.gameObject);
            }
        }
    }
    public void InitiateDestroySequence()
    {
        startTime = Time.time;
        destroySequenceInitiated = true;
        ps.Stop();
    }
}
