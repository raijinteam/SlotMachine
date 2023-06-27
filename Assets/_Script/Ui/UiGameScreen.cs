using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;

public class UiGameScreen : MonoBehaviour
{
    public Button btn_Spin;
    [SerializeField] private float flt_DelayOfTweSpin;
    [SerializeField] private Sprite img_Unselect;
    [SerializeField] private Sprite img_Select;
    

   

    private void OnEnable() {
        CoinHandler.instance.RunCoinLoanAnimation();
    }

    public void OnClick_OnSpinBtnClick() {

        AudioManager.instance.Play_BtnClikSfx();
        GridManager.instance.SpinClick();
        btn_Spin.interactable = false;
        btn_Spin.image.sprite = img_Unselect;
      
    }

    public void SelectBtnActive() {
        btn_Spin.interactable = true;
        btn_Spin.image.sprite = img_Select;
    }

   

   
}
