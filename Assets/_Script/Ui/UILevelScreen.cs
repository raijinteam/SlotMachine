using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class UILevelScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txt_Level;
    [SerializeField] private TextMeshProUGUI txt_Mesasage;
    
   
   
    private void OnEnable() {

       


        txt_Level.text = "Level " + LevelManager.instance.CurrentLevelNo;
        txt_Mesasage.text = " You have " + LevelManager.instance.CurrentLevel.SpinValue + " spins to pay $ "+ LevelManager.instance.CurrentLevel.RentValue
                               + " in taxes " ;
    }

    public void Onclick_OnReadBtnClick() {

        AudioManager.instance.Play_BtnClikSfx();
        if (LevelManager.instance.CurrentLevelNo == 1) {
            this.gameObject.SetActive(false);
            UiManager.instance.GetUiGamePlayScreen.gameObject.SetActive(true);
            UiManager.instance.GetUiGamePlayScreen.btn_Spin.gameObject.SetActive(true);
        }
        else {
            this.gameObject.SetActive(false);
            UiManager.instance.GetUiPowerupScreen.gameObject.SetActive(true);
            
          
        }
       
    }
}
