using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    private PlayerPrefsKey user_Key = new PlayerPrefsKey();
    public bool isMusic;
    public bool isSound;
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

    private void Update() {
        if (Input.GetKeyDown(KeyCode.U)) {
            PlayerPrefs.DeleteAll();
        }
    }

    private void Start() {

        if (PlayerPrefs.HasKey(user_Key.IsMusic)) {
            GetingData();
        }
        else {
            SetData();
        }

        AudioManager.instance.SetBackGroundMusic();
       
    }

    private void SetData() {

        PlayerPrefs.SetInt(user_Key.IsMusic, 1);
        isMusic = true;
        PlayerPrefs.SetInt(user_Key.IsSound, 1);
        isSound = true;
    }

    private void GetingData() {
        if (PlayerPrefs.GetInt(user_Key.IsMusic) == 1) {
            isMusic = true;
        }
        else {
            isMusic = false;
        }

        if (PlayerPrefs.GetInt(user_Key.IsSound) == 1) {
            isSound = true;
        }else {
            isSound = false;
        }
       
    }

    public void SetMusicData() {

        if (isMusic) {
            isMusic = false;
            PlayerPrefs.SetInt(user_Key.IsMusic, 0);
            AudioManager.instance.SetBackGroundMusic();
        }
        else {
            isMusic = true;
            PlayerPrefs.SetInt(user_Key.IsMusic, 1);
            AudioManager.instance.SetBackGroundMusic();
        }
    }

    public void SetSoundData() {
        if (isSound) {
            isSound = false;
            PlayerPrefs.SetInt(user_Key.IsSound, 0);
        }
        else {
            isSound = false;
            PlayerPrefs.SetInt(user_Key.IsSound, 1);
        }
    }
}
