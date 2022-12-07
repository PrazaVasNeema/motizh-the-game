using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    // Работа с абстракцией
    [SerializeField]
    private ParticleSystem m_rain; // Для абстракции, ибо может быть не система частит

    public void StartRain()
    {
        m_rain.Play();
    }
    public void StopRain()
    {
        m_rain.Stop();
    }
}
