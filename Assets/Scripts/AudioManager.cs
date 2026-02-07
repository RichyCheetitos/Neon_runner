using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Sources")]
    public AudioSource coinSFX;
    public AudioSource hurtSFX;
    public AudioSource stepSFX;

    // Métodos para ser llamados por los eventos
    public void PlayCoin() => coinSFX.Play();
    public void PlayHurt() => hurtSFX.Play();
    public void PlayStep() => stepSFX.Play();
}