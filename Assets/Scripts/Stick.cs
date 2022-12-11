using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Game
{

public class Stick : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<Collision, Vector3> onCollisionStone; // События для принятия решений

/*        [SerializeField]
        private UnityEvent<Vector3> SetForwardOnStart;*/

        private void Start()
        {
/*            SetForwardOnStart.Invoke(transform.forward);*/
        }

        private void Awake()
        {
//            Debug.Log($"{transform.up}");
        }

        private void Update()
        {
//            Debug.DrawRay(transform.position, transform.forward * 100, Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f), 10f);

        }


        private void OnCollisionEnter(Collision other)
    {
        Debug.Log(">>>");
        onCollisionStone.Invoke(other, transform.forward);
    }
}
}
