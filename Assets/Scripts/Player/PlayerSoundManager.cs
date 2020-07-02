using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundManager : MonoBehaviour
{
    [SerializeField]
    public AudioClip[] walkingSounds;
    [SerializeField]
    public AudioClip[] engagePower;

    public void PlayWalkingSound()
    {
        AudioSource.PlayClipAtPoint(walkingSounds[Random.Range(0, walkingSounds.Length)], Camera.main.transform.position);
    }


}
