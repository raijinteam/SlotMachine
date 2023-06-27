using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DiamondHands : MonoBehaviour
{
  
    [SerializeField]private int baseValue;
   
   
    [SerializeField] private List<GameObject> list_Coin;

    private int bitcoinSymboleIndex = 1;
    private int cardanoCoinIndex = 2;
    private int ethCoinSymboleIndex = 3;
    private int stableCoinIndex = 4;

   
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private float flt_StopAnimationTime;
    [SerializeField] private float yOffset;

    private void OnEnable() {
       
        GridManager.instance.SetCoinSetup += Instance_SetCoinSetup;
    }



    private void OnDisable() {
      
        GridManager.instance.SetCoinSetup -= Instance_SetCoinSetup;
    }

   

    public void Instance_SetSynergy() {

        bool hasFoundSynergy = false;
        baseValue = 0;
        list_Coin.Clear();
      
        for (int i = 0; i < GridManager.instance.list_ActivateInHirachy.Count; i++) {

          

            if (bitcoinSymboleIndex == GridManager.instance.list_ActivateInHirachy[i].GetComponent<SymbolData>().mySymbolIndex) {
                GridManager.instance.list_ActivateInHirachy[i].GetComponentInParent<RawMotion>().VFXForMOtion();
                StopAnimation();
                list_Coin.Add(GridManager.instance.list_ActivateInHirachy[i].GetComponent<SymbolData>().gameObject);
                hasFoundSynergy = true;
            }
            else if (cardanoCoinIndex == GridManager.instance.list_ActivateInHirachy[i].GetComponent<SymbolData>().mySymbolIndex) {
                list_Coin.Add(GridManager.instance.list_ActivateInHirachy[i].GetComponent<SymbolData>().gameObject);
                GridManager.instance.list_ActivateInHirachy[i].GetComponentInParent<RawMotion>().VFXForMOtion();
                StopAnimation();
                hasFoundSynergy = true;

            }
            else if (ethCoinSymboleIndex == GridManager.instance.list_ActivateInHirachy[i].GetComponent<SymbolData>().mySymbolIndex) {
                list_Coin.Add(GridManager.instance.list_ActivateInHirachy[i].GetComponent<SymbolData>().gameObject);
                GridManager.instance.list_ActivateInHirachy[i].GetComponentInParent<RawMotion>().VFXForMOtion();
                StopAnimation();
                hasFoundSynergy = true;


            }
            else if (stableCoinIndex == GridManager.instance.list_ActivateInHirachy[i].GetComponent<SymbolData>().mySymbolIndex) {
                list_Coin.Add(GridManager.instance.list_ActivateInHirachy[i].GetComponent<SymbolData>().gameObject);
                GridManager.instance.list_ActivateInHirachy[i].GetComponentInParent<RawMotion>().VFXForMOtion();
                StopAnimation();
                hasFoundSynergy = true;


            }

        }

        if (hasFoundSynergy) {
            AudioManager.instance.Play_SynergySfx();
        }

     
            baseValue += (list_Coin.Count / 3);

      
    }

    private void Instance_SetCoinSetup(object sender, System.EventArgs e) {
        CoinHandler.instance.SpawnCoin(baseValue, transform.position);
       
    }

    private void StopAnimation() {

        Sequence SEQ = DOTween.Sequence();

        float startPostion = rectTransform.localPosition.y;
        SEQ.Append(rectTransform.DOLocalMoveY(startPostion - yOffset, flt_StopAnimationTime)).SetEase(Ease.Linear).
           Append(rectTransform.DOLocalMoveY(startPostion + yOffset, flt_StopAnimationTime).SetLoops(3, LoopType.Yoyo)).SetEase(Ease.Linear)
           .Append(rectTransform.DOLocalMoveY(startPostion, flt_StopAnimationTime).SetEase(Ease.Linear));


    }

}
