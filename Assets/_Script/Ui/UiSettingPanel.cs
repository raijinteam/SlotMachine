using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiSettingPanel : MonoBehaviour
{
    [SerializeField] private GameObject obj_Music_On;
    [SerializeField] private GameObject obj_Sound_On;
    [SerializeField] private GameObject obj_Music_Off;
    [SerializeField] private GameObject obj_Sound_Off;

    private void OnEnable() {
        UiSettingScreen();
    }

    public void Onclick_CloseBtnClick() {
        AudioManager.instance.Play_BtnClikSfx();
        this.gameObject.SetActive(false);

        if (UiManager.instance.GetUiPowerupScreen.gameObject.activeSelf) {
            return;
        }
        else if (UiManager.instance.GetUIPassiveScreen.gameObject.activeSelf) {
            return;
        }
        UiManager.instance.GetUiHomeScreen.gameObject.SetActive(true);
    }

    public void Onclick_OnMusicBtnClick() {
        AudioManager.instance.Play_BtnClikSfx();
       
       
        if (DataManager.instance.isMusic) {

          

            obj_Music_On.gameObject.SetActive(false);
            obj_Music_Off.gameObject.SetActive(true);
        }
        else {
          
            obj_Music_On.gameObject.SetActive(true);
            obj_Music_Off.gameObject.SetActive(false);
        }

        DataManager.instance.SetMusicData();
    }

    public void OnClick_OnSoundBtnClick() {
        AudioManager.instance.Play_BtnClikSfx();
      

        if (DataManager.instance.isSound) {

            obj_Sound_On.gameObject.SetActive(false);
            obj_Sound_Off.gameObject.SetActive(true);
        }
        else {

            obj_Sound_On.gameObject.SetActive(true);
            obj_Sound_Off.gameObject.SetActive(false);
        }

        DataManager.instance.SetSoundData();
    }

    private void UiSettingScreen() {
        if (DataManager.instance.isMusic) {
            obj_Music_On.gameObject.SetActive(true);
            obj_Music_Off.gameObject.SetActive(false);
        }
        else {
            obj_Music_On.gameObject.SetActive(false);
            obj_Music_Off.gameObject.SetActive(true);
        }


        if (DataManager.instance.isSound) {
            obj_Sound_On.gameObject.SetActive(true);
            obj_Sound_Off.gameObject.SetActive(false);
        }
        else {
            obj_Sound_Off.gameObject.SetActive(true);
            obj_Sound_On.gameObject.SetActive(false);
        }
    }
}
