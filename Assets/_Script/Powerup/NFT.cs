using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NFT : MonoBehaviour {

    [SerializeField] private SymbolData symbolData;
     private int baseValue ;
    public int BaseValue { get; set; }

    private int ethCoinSymboleIndex = 2;
    private int fomoBuyerIndex = 20;


    private void OnEnable() {
        baseValue = symbolData.Basevalue;   
        BaseValue = baseValue;
       
        GridManager.instance.SetCoinSetup += Instance_SetCoinSetup;
    }
    private void OnDisable() {

       
        GridManager.instance.SetCoinSetup -= Instance_SetCoinSetup;
    }

    public void Instance_SetSynergy() {

        bool hasfouneSynergy = false;
        int ExtraValue = 0;
        AdjucentData adjucentData = GetComponentInParent<AdjucentData>();
        for (int i = 0; i < adjucentData.all_Adjucent.Length; i++) {

            if (adjucentData.all_Adjucent[i].transform.childCount != 0) {

                if (fomoBuyerIndex == GridManager.instance.list_ActivateInHirachy[i].GetComponent<SymbolData>().mySymbolIndex) {

                    ExtraValue++;
                    adjucentData.all_Adjucent[i].GetComponent<RawMotion>().VFXForMOtion();
                    transform.GetComponentInParent<RawMotion>().VFXForMOtion();
                    hasfouneSynergy = true;
                    CheckingEthGrid();
                }

            }

        }

        if (hasfouneSynergy) {
            AudioManager.instance.Play_SynergySfx();
        }

       
        baseValue += ExtraValue;
        BaseValue += ExtraValue;
    }

  

    private void Instance_SetCoinSetup(object sender, EventArgs e) {
        if (BaseValue<0) {
            BaseValue = 0;
        }

        CoinHandler.instance.SpawnCoin(BaseValue, transform.position);

    }
    private void CheckingEthGrid() {


        for (int i = 0; i < GridManager.instance.list_ActivateInHirachy.Count; i++) {

            if (ethCoinSymboleIndex == GridManager.instance.list_ActivateInHirachy[i].GetComponent<SymbolData>().mySymbolIndex) {

                GridManager.instance.list_ActivateInHirachy[i].GetComponentInParent<RawMotion>().VFXForMOtion();
                transform.GetComponentInParent<RawMotion>().VFXForMOtion();
                BaseValue++;
            }



        }
    }
}