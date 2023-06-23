using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class UiPayRentScreen : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI txt_Message;
  
    private void OnEnable() {
        Message();
    }
    private void Message() {

       
        txt_Message.text = "Pay taxes of $"  + LevelManager.instance.CurrentLevel.RentValue;
    }
    public void OnClickOnBtn_PayClick() {

        AudioManager.instance.Play_BtnClikSfx();
        GameManager.instance.UpdateScore(-LevelManager.instance.CurrentLevel.RentValue);
        LevelManager.instance.IncreasingLevel();
        UiManager.instance.GetLevelScreen.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }

    
}
