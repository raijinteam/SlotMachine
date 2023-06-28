using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadCat : MonoBehaviour
{
    [SerializeField] private SymbolData symbolData;
    [SerializeField] private int persantageOfFurspawn;
    private int bitcoinSymboleIndex = 1;
    private int cardanoCoinIndex = 2;
    private int ethCoinSymboleIndex = 3;
    private int stableCoinIndex = 4;

    public bool shouldSpawnThisRound = false;
    public bool ShouldSpawnObj() {
        int index = Random.Range(0, 100);
        if (index < persantageOfFurspawn) {

            shouldSpawnThisRound = true;
        }
        else {
            shouldSpawnThisRound = false;
        }

        return shouldSpawnThisRound;
    }

    public void Instance_SetSpawnObj() {
       
       GridManager.instance.OnExtraFurAdd();       
    }

    public void Instance_SetSynergy() {

       bool hasFoundSynergy = false;
        symbolData.shouldSynergy = false;

        AdjucentData adjucentData = transform.GetComponentInParent<AdjucentData>();
        for (int i = 0; i < adjucentData.all_Adjucent.Length; i++) {

            if (adjucentData.all_Adjucent[i].transform.childCount == 0) {
                continue;
            }

            if (bitcoinSymboleIndex == adjucentData.all_Adjucent[i].GetComponentInChildren<SymbolData>().mySymbolIndex) {

                BitCoin bitCoin = adjucentData.all_Adjucent[i].GetComponentInChildren<BitCoin>();
                bitCoin.BaseValue *= 2;
                adjucentData.all_Adjucent[i].GetComponent<RawMotion>().VFXForMOtion();
                transform.GetComponentInParent<RawMotion>().VFXForMOtion();
                hasFoundSynergy = true;
                symbolData.shouldSynergy = true;
            }
            else if (cardanoCoinIndex == adjucentData.all_Adjucent[i].GetComponentInChildren<SymbolData>().mySymbolIndex) {

                CardanoCoin cardanoCoin = adjucentData.all_Adjucent[i].GetComponentInChildren<CardanoCoin>();
                cardanoCoin.BaseValue *= 2;
                adjucentData.all_Adjucent[i].GetComponent<RawMotion>().VFXForMOtion();
                transform.GetComponentInParent<RawMotion>().VFXForMOtion();
                symbolData.shouldSynergy = true;
                hasFoundSynergy = true;
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

        if (hasFoundSynergy) {
            AudioManager.instance.Play_SynergySfx();
        }

       
    }

   
}
