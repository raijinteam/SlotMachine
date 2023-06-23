using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] private AudioSource audioSource_BgMusic;
    [SerializeField] private AudioSource audioSource_CoinMusic;
    [SerializeField] private AudioSource audioSource_Synegy_Music;
    [SerializeField] private AudioSource audioSource_btn_Music;

    private void Awake() {
        DontDestroyOnLoad(this);

        if (FindObjectsOfType(GetType()).Length > 1) {
            Destroy(gameObject);
        }

        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
        }
        instance = this;
    }

    public void Play_CoinSfx() {
        if (!DataManager.instance.isSound) {
            return;
        }
        audioSource_CoinMusic.Play();
    }

    public void Play_SynergySfx() {

        if (!DataManager.instance.isSound) {
            return;
        }
        audioSource_Synegy_Music.Play();
    }

    public void Play_BtnClikSfx() {
        if (!DataManager.instance.isSound) {
            return;
        }

        audioSource_btn_Music.Play();
    }

    public void SetBackGroundMusic() {
        if (DataManager.instance.isMusic) {
            audioSource_BgMusic.Play();
        }
        else {
            audioSource_BgMusic.Stop();
        }
    }
}
