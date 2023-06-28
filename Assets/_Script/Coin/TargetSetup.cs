using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TargetSetup : MonoBehaviour
{
    [SerializeField] private TextMesh txt_Mesh;
    private float flt_Y_DownPostion;
    private float flt_Y_TopPostion = -2.2f;
    private int Coin;

    private bool isanimationStart;

    //[SerializeField] private Canvas canvas;
    [SerializeField] private RectTransform rectTransform;

    //<Summary>
    //In this Script Set up All Coin Animation
    // Target Up Animation
    // Taget DownAnimation
    // TextOf Coin
    // reset Coin
    //</Summary>

    private void OnEnable() {
        Camera camera = Camera.main;  // Use the camera that can see the canvas

        Vector2 screenPosition = RectTransformUtility.WorldToScreenPoint(camera, rectTransform.position);
        Vector3 worldPosition = camera.ScreenToWorldPoint(screenPosition);

        transform.position = new Vector3(worldPosition.x, worldPosition.y, 0);


        flt_Y_DownPostion = transform.localPosition.y;

        txt_Mesh.gameObject.SetActive(false);
    }


    public void TargetUpAnimation(float time) {

        isanimationStart = true;
        transform.DOLocalMoveY(flt_Y_TopPostion, time);
        

    }
    public void TargetDownAmiantion(float time) {

        Sequence seq = DOTween.Sequence();
        seq.Append(transform.DOLocalMoveY(flt_Y_DownPostion, time)).AppendInterval(time).AppendCallback(CheckingGameOver);
       
        
    }
    private void CheckingGameOver() {
        GameManager.instance.GetTargetofCoin().gameObject.SetActive(false);
        isanimationStart = false;
        if (GameManager.instance.Score < 0) {
            UiManager.instance.GetUiGamePlayScreen.gameObject.SetActive(false);
            UiManager.instance.GetGameoverScreen.gameObject.SetActive(true);
        }
    }
    public void TargetTextChange( int Value) {

        Coin += Value;
        txt_Mesh.text = Coin.ToString();
        txt_Mesh.gameObject.SetActive(true);

    }

    // if Spin Chnage ValueChange
    public void resetCoin() {
        LevelManager.instance.UpdateCurrentLevelCoin(Coin);
        Coin = 0;
        txt_Mesh.text = Coin.ToString();
        txt_Mesh.gameObject.SetActive(false);
    }
}
