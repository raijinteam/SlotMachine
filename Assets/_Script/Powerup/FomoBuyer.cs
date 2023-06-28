using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FomoBuyer : MonoBehaviour
{
    [SerializeField] private SymbolData symbolData;
     private int baseValue;
    public int BaseValue { get; set; }

    private int bitcoinSymboleIndex = 1;
    private int cardanoCoinIndex = 2;
    private int ethCoinSymboleIndex = 3;
    private int stableCoinIndex = 4;

    private void OnEnable() {
        baseValue = symbolData.Basevalue;
        BaseValue = baseValue;
    
        GridManager.instance.SetCoinSetup += Instance_SetCoinSetup;
    }
    private void OnDisable() {

        GridManager.instance.SetCoinSetup -= Instance_SetCoinSetup;
    }

    public void Instance_SetSynergy() {


        symbolData.shouldSynergy = false;
        bool hasFoundSynergy = false;

        AdjucentData adjucentData = GetComponentInParent<AdjucentData>();
        if (adjucentData == null) {
            return;
        }
        for (int i = 0; i < adjucentData.all_Adjucent.Length; i++) {

            if (adjucentData.all_Adjucent[i].transform.childCount != 0) {

               

                if (bitcoinSymboleIndex == adjucentData.all_Adjucent[i].GetComponentInChildren<SymbolData>().mySymbolIndex) {

                    BitCoin bitCoin = adjucentData.all_Adjucent[i].GetComponentInChildren<BitCoin>();
                    bitCoin.BaseValue *= 2;
                    adjucentData.all_Adjucent[i].GetComponent<RawMotion>().VFXForMOtion();
                    transform.GetComponentInParent<RawMotion>().VFXForMOtion();
                    hasFoundSynergy = true;
                    symbolData.shouldSynergy = true;
                }
                else if (cardanoCoinIndex == adjucentData.all_Adjucent[i].GetComponentInChildren<SymbolData>().mySymbolIndex) {

                    CardanoCoin caradnoCoin = adjucentData.all_Adjucent[i].GetComponentInChildren<CardanoCoin>();
                    caradnoCoin.BaseValue *= 2;
                    adjucentData.all_Adjucent[i].GetComponent<RawMotion>().VFXForMOtion();
                    transform.GetComponentInParent<RawMotion>().VFXForMOtion();
                    hasFoundSynergy = true;
                    symbolData.shouldSynergy = true;
                }
                else if (ethCoinSymboleIndex == adjucentData.all_Adjucent[i].GetComponentInChildren<SymbolData>().mySymbolIndex) {

                    ETHCoin eTHCoin = adjucentData.all_Adjucent[i].GetComponentInChildren<ETHCoin>();
                    eTHCoin.BaseValue *= 2;
                    adjucentData.all_Adjucent[i].GetComponent<RawMotion>().VFXForMOtion();
                    transform.GetComponentInParent<RawMotion>().VFXForMOtion();
                    hasFoundSynergy = true;
                    symbolData.shouldSynergy = true;
                }
                else if (stableCoinIndex == adjucentData.all_Adjucent[i].GetComponentInChildren<SymbolData>().mySymbolIndex) {

                    StableCoin stableCoin = adjucentData.all_Adjucent[i].GetComponentInChildren<StableCoin>();
                    stableCoin.BaseValue *= 2;
                    adjucentData.all_Adjucent[i].GetComponent<RawMotion>().VFXForMOtion();
                    transform.GetComponentInParent<RawMotion>().VFXForMOtion();
                    hasFoundSynergy = true;
                    symbolData.shouldSynergy = true;
                }

            }

        }

        if (hasFoundSynergy) {
            AudioManager.instance.Play_SynergySfx();
        }
    }

   

    private void Instance_SetCoinSetup(object sender, EventArgs e) {

        if (BaseValue<0) {
            baseValue = 0;
        }
        CoinHandler.instance.SpawnCoin(BaseValue, transform.position);
        BaseValue = baseValue;
    }


  
}
