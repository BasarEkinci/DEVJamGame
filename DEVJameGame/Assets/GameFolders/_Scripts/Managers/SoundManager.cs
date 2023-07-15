using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    private AudioSource[] audioSource;
    [SerializeField] AudioClip[] soundEffects;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        audioSource = GetComponentsInChildren<AudioSource>();
    }

    public void PlaySoundEffect(int index)
    {
        audioSource[index].PlayOneShot(soundEffects[index]);
    }

    public void PlaySound(int index)
    {
        if(!audioSource[index].isPlaying)
            audioSource[index].Play();
    }

    public void StopSound(int index)
    {
        if(audioSource[index].isPlaying)
            audioSource[index].Stop();
    }
}
