using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioClip[] m_audioClips;

    private AudioSource m_audioSource;

	private void Awake ()
    {
        m_audioSource = GetComponent<AudioSource>();
    }

    void PlaySound(int _index)
    {
        m_audioSource.clip = m_audioClips[_index];
        m_audioSource.Play();
    }

}
