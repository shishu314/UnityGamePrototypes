using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip arrowHitSound, pullBowSound;
    static AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        arrowHitSound = Resources.Load<AudioClip>("ArrowHit");
        pullBowSound = Resources.Load<AudioClip>("PullBow");
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string sound)
    {
        switch(sound)
        {
            case "arrowHit":
                audioSource.PlayOneShot(arrowHitSound);
                break;
            case "pullBow":
                audioSource.PlayOneShot(pullBowSound);
                break;
            default:
                break;
        }
    }
}
