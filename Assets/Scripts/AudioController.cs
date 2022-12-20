using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField]
    public AudioSource m_hitRockSoundEffect;
    [SerializeField]
    public AudioSource m_pushButtonSoundEffect;
    [SerializeField]
    public AudioSource m_pushButtonSoundEffectExit;
    [SerializeField]
    public AudioSource m_music;
    
    public void PlayButtonSound()
    {
        m_pushButtonSoundEffect.Play();
    }
    public void PlayButtonExitSound()
    {
        m_pushButtonSoundEffectExit.Play();
    }

    public void SetMusicStatus(int musicStatus)
    {
        if (musicStatus == 0)
        {
            m_music.Stop();
        }
        else
        {
            m_music.Play();
        }
    }
}
