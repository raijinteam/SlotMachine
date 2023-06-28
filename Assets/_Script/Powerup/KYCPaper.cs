using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class KYCPaper : MonoBehaviour
{
    [SerializeField] private SymbolData symbolData;
     private int baseValue;
    private int fomoBuyerIndex = 20;
    private int HodlerIndex = 22;

    private void OnEnable() {

        baseValue = symbolData.Basevalue;
      
        GridManager.instance.SetCoinSetup += Instance_SetCoinSetup;
    }
    private void OnDisable() {

       
        GridManager.instance.SetCoinSetup -= Instance_SetCoinSetup;
    }

   
    public void Instance_SetSynergy() {

        symbolData.shouldSynergy = false;
        bool hasfoundSynergy = false;   

        AdjucentData adjucentData = GetComponentInParent<AdjucentData>();
        for (int i = 0; i < adjucentData.all_Adjucent.Length; i++) {

            if (adjucentData.all_Adjucent[i].transform.childCount != 0) {

                if (fomoBuyerIndex == adjucentData.all_Adjucent[i].GetComponentInChildren<SymbolData>().mySymbolIndex) {

                    FomoBuyer fomoBuyer = adjucentData.all_Adjucent[i].GetComponentInChildren<FomoBuyer>();
                    fomoBuyer.BaseValue += 1;
                    adjucentData.all_Adjucent[i].GetComponent<RawMotion>().VFXForMOtion();
                    transform.GetComponentInParent<RawMotion>().VFXForMOtion();
                    hasfoundSynergy = true;
                    symbolData.shouldSynergy = true;
                }
                else if (HodlerIndex == adjucentData.all_Adjucent[i].GetComponentInChildren<SymbolData>().mySymbolIndex) {

                    Hodler hodler = adjucentData.all_Adjucent[i].GetComponentInChildren<Hodler>();
                    hodler.BaseValue += 1;
                    adjucentData.all_Adjucent[i].GetComponent<RawMotion>().VFXForMOtion();
                    transform.GetComponentInParent<RawMotion>().VFXForMOtion();
                    hasfoundSynergy = true;
                    symbolData.shouldSynergy = true;
                }
               

            }

        }
        if (hasfoundSynergy) {
            AudioManager.instance.Play_SynergySfx();
        }
    }
    private void Instance_SetCoinSetup(object sender, EventArgs e) {

        CoinHandler.instance.SpawnCoin(baseValue, transform.position);
    }

}
