using UnityEngine;

public class BallSound : MonoBehaviour
{
    [Header("Audio Clips")]
    public AudioClip rollSound; // صدای حرکت توپ
    public AudioClip hitSound;  // صدای برخورد با پین‌ها

    private AudioSource audioSource;

    private void Start()
    {
        // دریافت کامپوننت AudioSource
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayRollSound()
    {
        // پخش صدای حرکت توپ
        audioSource.clip = rollSound;
        audioSource.loop = true; // اگر می‌خواهید صدا تکرار شود
        audioSource.Play();
    }

    public void PlayHitSound()
    {
        // پخش صدای برخورد
        audioSource.clip = hitSound;
        audioSource.loop = false;
        audioSource.Play();
    }

    public void StopRollSound()
    {
        // توقف صدای حرکت
        audioSource.Stop();
    }
}
