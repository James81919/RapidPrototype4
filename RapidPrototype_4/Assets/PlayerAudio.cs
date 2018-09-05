using UnityEngine.Audio;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioClip[] m_audioClips;

    public AudioSource[] m_audioSource;
    public static PlayerAudio instance;

	private void Awake ()
    {
        m_audioSource = new AudioSource[m_audioClips.Length];
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        for (int i = 0; i < m_audioSource.Length; i++) {
            
            m_audioSource[i] = gameObject.AddComponent<AudioSource>();
            m_audioSource[i].clip = m_audioClips[i];
            m_audioSource[i].playOnAwake = false;
        }

        m_audioSource[0].loop = true;
        m_audioSource[1].loop = false;
        m_audioSource[0].Play();
    }

    public void PlaySound(int _index)
    {
        m_audioSource[_index].Play();
    }

    public void SetBackGroundMusic(float _volume)
    {
        m_audioSource[0].volume = _volume;
        m_audioSource[1].volume = _volume;
    }

    public void SetGameEffectSound(float _volume)
    {
        for (int i = 2; i < m_audioSource.Length; i++)
        {
            m_audioSource[i].volume = _volume;
        }
    }

}
