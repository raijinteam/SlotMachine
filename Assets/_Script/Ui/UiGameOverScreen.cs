using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiGameOverScreen : MonoBehaviour
{
   

    public void OnclickOnReloadBtnClick() {
        AudioManager.instance.Play_BtnClikSfx();
        SceneManager.LoadScene(0);
    }
}
