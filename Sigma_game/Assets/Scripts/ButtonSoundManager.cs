using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class ButtonSoundManager : MonoBehaviour {

    public AudioClip hit;
    private Button button { get { return GetComponent<Button>(); } }
    private AudioSource audioSource { get { return GetComponent<AudioSource>(); } }

    void Start() {

        gameObject.AddComponent<AudioSource>();
        audioSource.clip = hit;
        audioSource.playOnAwake = false;

        button.onClick.AddListener(()=>PlaySound());
    }

    void PlaySound() {

        audioSource.PlayOneShot(hit, 0.7f);
    }
    
}
