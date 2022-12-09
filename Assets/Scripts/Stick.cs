using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Game
{

public class Stick : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<Collision> onCollisionStone; // События для принятия решений



    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(">>>");
        onCollisionStone.Invoke(other);
    }
}
}
