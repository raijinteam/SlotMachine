using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiHomeScreen : MonoBehaviour
{
    

   

    public void Onclick_OnSettingBtnClick() {

        AudioManager.instance.Play_BtnClikSfx();
        this.gameObject.SetActive(false);
        UiManager.instance.GetUiSettingScreen.gameObject.SetActive(true);
    }
    public void Onclick_OnStartBtnClick() {
        AudioManager.instance.Play_BtnClikSfx();
        this.gameObject.SetActive(false);
        UiManager.instance.GetLevelScreen.gameObject.SetActive(true);
    }
}
