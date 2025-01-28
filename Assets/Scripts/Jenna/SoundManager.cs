using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public enum AudioTag
{
    Brew,
    Grind,
    Click,
    Complete,
    Error,
    Drag,
    Recipe
}
public class SoundManager : MonoBehaviour
{
    // SoundManager.Instance.PlayEffect(AudioTag.);
    public static SoundManager Instance;

    [SerializeField] private AudioClip brewed_potion;
    [SerializeField] private AudioClip ingredient_grind;
    [SerializeField] private AudioClip plop_1;
    [SerializeField] private AudioClip plop_2;
    [SerializeField] private AudioClip coins;
    [SerializeField] private AudioClip error;
    [SerializeField] private AudioClip pageTurn;

    private List<AudioSource> audioSources = new List<AudioSource>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayEffect(AudioTag desc)
    {
        AudioClip clip = GetClipFromTag(desc);
        if (clip != null)
        {
            AudioSource newSource = CreateAudioSource(clip);
            newSource.volume = 1.5f;
            newSource.Play();
            StartCoroutine(CleanupAudioSource(newSource));
        }
        else
        {
            Debug.Log("Sound was null");
        }
    }

    private AudioClip GetClipFromTag(AudioTag desc)
    {
        switch (desc)
        {
            case AudioTag.Brew: return brewed_potion;
            case AudioTag.Grind: return ingredient_grind;
            case AudioTag.Click: return plop_1;
            case AudioTag.Complete: return coins;
            case AudioTag.Error: return error;
            case AudioTag.Drag: return plop_2;
            case AudioTag.Recipe: return pageTurn;
            default: return null;
        }
    }

    private AudioSource CreateAudioSource(AudioClip clip)
    {
        AudioSource source = gameObject.AddComponent<AudioSource>();
        source.clip = clip;
        audioSources.Add(source);
        return source;
    }

    private System.Collections.IEnumerator CleanupAudioSource(AudioSource source)
    {
        yield return new WaitForSeconds(source.clip.length);
        audioSources.Remove(source);
        Destroy(source);
    }
}
